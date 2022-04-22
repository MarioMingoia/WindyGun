using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class windArea : MonoBehaviour
{
    public List<Rigidbody> rbInWindList = new List<Rigidbody>();
    public float strength;
    [SerializeField]
    float originalStrength;

    float clampedMax;

    //raycast
    float raycastLength;

    private void Start()
    {
        originalStrength = strength;

        clampedMax = originalStrength * 2;

        ParticleSystem ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        var sh = ps.shape;
        sh.scale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
    }
    private void FixedUpdate()
    {

        try
        {
            if (rbInWindList.Count > 0)
            {
                for (int i = 0; i < rbInWindList.Count; i++)
                {
                    if(rbInWindList[i] != null)
                    {
                        if (rbInWindList[i].gameObject.tag.Contains("Player") && !rbInWindList[i].gameObject.GetComponent<glider>().gliderObj.activeInHierarchy)
                        {
                            Vector3 rotationInEuler = transform.rotation.eulerAngles;

                            float tiltX = Mathf.Abs(rotationInEuler.x);
                            if (-45 < tiltX && tiltX < 45)
                            {
                                rbInWindList[i].velocity = transform.forward * strength;
                            }
                            if (tiltX > 315 && tiltX < 360)
                            {
                                rbInWindList[i].velocity = transform.forward * strength;
                            }
                        }
                        else if (!rbInWindList[i].gameObject.tag.Contains("Player") || rbInWindList[i].gameObject.GetComponent<glider>().gliderObj.activeInHierarchy)
                        {
                            rbInWindList[i].velocity = transform.forward * strength;
                        }
                    }
                    else
                    {
                        rbInWindList.RemoveAt(i);
                    }

                }
            }
        }
        catch 
        {

          
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rbObj = other.gameObject.GetComponent<Rigidbody>();

        if (rbInWindList.Count >= 1 || other.gameObject.name.Contains("Winch"))
        {
            strength += .1f;

            strength = Mathf.Clamp(strength, originalStrength, clampedMax);
        }

        if (rbObj != null && !rbInWindList.Contains(rbObj) && !other.gameObject.CompareTag("Spinning") && !other.gameObject.CompareTag("WindArea"))
            rbInWindList.Add(rbObj);

        try
        {
            if (other.gameObject.CompareTag("Conveyor"))
                rbObj.isKinematic = false;
        }
        catch 
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {

        Rigidbody rbObj = other.gameObject.GetComponent<Rigidbody>();

        try
        {
            if (other.gameObject.CompareTag("Conveyor"))
                rbObj.isKinematic = true;
        }
        catch
        {
        }
        strength = originalStrength;
        if (rbObj != null && rbInWindList.Contains(rbObj))
            rbInWindList.Remove(rbObj);
    }
}
