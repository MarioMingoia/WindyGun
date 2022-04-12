using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPush : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
    }
}
