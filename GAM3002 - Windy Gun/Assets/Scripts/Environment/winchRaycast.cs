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

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            print(hit.transform.gameObject.name);

            if (hit.collider.CompareTag(tagName))
            {
                int childCount = hit.transform.childCount - 1;

                ws.platform = hit.transform.gameObject;
                ws.platformLine = hit.transform.GetChild(childCount).gameObject;
            }
            else
            {
                ws.platform = null;
                ws.platformLine = null;
            }
        }
    }
        
}
