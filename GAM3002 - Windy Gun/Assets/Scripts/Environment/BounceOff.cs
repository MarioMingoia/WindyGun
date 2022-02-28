using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BounceOff : MonoBehaviour
{
    public GameObject me;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("curvedsquare"))
        {
            Vector3 pos = other.ClosestPointOnBounds(transform.position);

            Vector3 inDirection = Vector3.Reflect(pos - transform.position, other.transform.forward);

            Quaternion qn = Quaternion.Euler(transform.rotation.x, transform.rotation.y + -90, transform.rotation.z);

            GameObject go = Instantiate(me, pos + inDirection, qn);
            go.GetComponent<BoxCollider>().isTrigger = true;
            go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            go.GetComponent<windArea>().strength = GetComponent<windArea>().strength;
        }
    }
}


