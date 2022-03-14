using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    public string triggerTag;
    public Material activeWire;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material = activeWire;

            }
        }
    }
}
