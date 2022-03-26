using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winchRaycast : MonoBehaviour
{
    [SerializeField]
    string tagName;

    winchScript ws;

    public Transform raycastPos;

    [SerializeField]
    float rayDistance;

    public GameObject plate;
    public GameObject winch;

    public LayerMask ignoreMe;
    void Start()
    {
        ws = GetComponent<winchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            raycastStuff();
        }
        catch
        {

        }
    }

    void raycastStuff()
    {
        Debug.DrawRay(raycastPos.transform.position, -transform.up * rayDistance, Color.green);

        Ray ray = new Ray(raycastPos.transform.position, -transform.up * rayDistance);
        //has the ray go from the front of the player
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, ~ignoreMe))
        {
            if (hit.collider.CompareTag(tagName))
            {
                ws.platform = hit.transform.gameObject;
                ws.platformLine = hit.transform.GetChild(0).gameObject;

                plate.GetComponent<startSpawning>().startSpawningBool = true;

                winch.GetComponent<winchScript>().enabled = false;
            }
            else
            {
                ws.platform = null;
                ws.platformLine = null;
                plate.GetComponent<startSpawning>().startSpawningBool = false;
                winch.GetComponent<winchScript>().enabled = true;


            }
        }
    }
        
}
