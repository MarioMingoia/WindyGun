using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public List<string> tags;
    public Transform endPoint;
    public float speed;
    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (tags.Contains(other.gameObject.tag))
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
            }
        }
        catch
        {
        }      

    }
}
