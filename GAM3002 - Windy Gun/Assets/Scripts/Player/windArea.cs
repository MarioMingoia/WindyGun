using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windArea : MonoBehaviour
{
    public List<Rigidbody> rbInWindList = new List<Rigidbody>();
    public float strength;
    public Vector3 windDirection;

    [SerializeField]
    float originalStrength;

    float clampedMax;

    //raycast
    float raycastLength;

    private void Start()
    {
        originalStrength = strength;

        clampedMax = originalStrength * 2;
    }
    private void FixedUpdate()
    {
        try
        {
            if (rbInWindList.Count > 0)
            {
                foreach (Rigidbody rb in rbInWindList)
                {
                    if (rb == null)
                    {
                        rbInWindList.Remove(rb);
                    }

                    if (rb.gameObject.name == "player")
                    {
                        Vector3 rotationInEuler = transform.rotation.eulerAngles;


                        float tiltX = Mathf.Abs(rotationInEuler.x);

                        if (tiltX > -45 && tiltX < 45 || tiltX > 315 && tiltX < 405)
                        {
                            rb.velocity = transform.forward * strength;
                        }
                    }
                    else
                    {
                        rb.velocity = transform.forward * strength;
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

        if (rbObj != null && !rbInWindList.Contains(rbObj))
            rbInWindList.Add(rbObj);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rbObj = other.gameObject.GetComponent<Rigidbody>();
        strength = originalStrength;
        if (rbObj != null && rbInWindList.Contains(rbObj))
            rbInWindList.Remove(rbObj);

    }
}
