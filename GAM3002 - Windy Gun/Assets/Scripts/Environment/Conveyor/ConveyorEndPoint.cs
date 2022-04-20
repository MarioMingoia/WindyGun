using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorEndPoint : ConveyorBelt
{
    public GameObject newPos;

    private void Start()
    {
        endPoint = GetComponent<ConveyorBelt>().endPoint;
    }
    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (Vector3.Distance(other.transform.position, endPoint.position) <= 1f)
            {
                other.transform.position = newPos.transform.position;
            }

        }
        catch
        {

        }
    }
} 
