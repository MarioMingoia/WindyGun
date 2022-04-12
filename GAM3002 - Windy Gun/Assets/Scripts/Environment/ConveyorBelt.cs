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
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i]))
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
                }

            }
        }
        catch
        {
        }


       

    }
}
