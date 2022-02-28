using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public List<string> tags;
    public Transform endPoint;
    public float speed;
    public GameObject newPos;
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (other.gameObject.CompareTag(tags[i]))
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);

                if (Vector3.Distance(other.transform.position, endPoint.position) <= 1f)
                {
                    print("123");
                    other.transform.position = newPos.transform.position;
                }

            }

        }

       

    }
}
