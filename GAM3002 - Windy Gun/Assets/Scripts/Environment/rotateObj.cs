using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour
{

    public GameObject objtoRotate;
    public string triggerTag;
    public Quaternion targetRot;
    Quaternion originalRot;
    // Start is called before the first frame update
    void Start()
    {
        originalRot = objtoRotate.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
            objtoRotate.transform.rotation = Quaternion.Euler(targetRot.x, targetRot.y, targetRot.z);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
            objtoRotate.transform.rotation = Quaternion.Euler(originalRot.x, originalRot.y, originalRot.z);
    }
}
