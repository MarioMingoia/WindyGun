using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNPillar : MonoBehaviour
{
    public Vector3 myCenter;
    public GameObject plrGun, firePos;

    // Start is called before the first frame update
    void Start()
    {
        myCenter = GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).RotateAround(myCenter, Vector3.up, 10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            plrGun.SetActive(true);
            firePos.SetActive(true);
            other.gameObject.GetComponent<shootingBullets>().enabled = true;
        }
    }
}
