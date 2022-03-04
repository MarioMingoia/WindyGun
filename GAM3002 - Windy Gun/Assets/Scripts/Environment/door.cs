using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject doorObj;
    public GameObject target;
    public Vector3 original;

    [SerializeField]
    string tagName;

    bool close;
    // Start is called before the first frame update
    void Start()
    {
        original = doorObj.transform.localPosition;
        close = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (close)
            doorObj.transform.localPosition = Vector3.MoveTowards(doorObj.transform.localPosition, original, 5f * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            doorObj.transform.localPosition = Vector3.MoveTowards(doorObj.transform.localPosition, target.transform.localPosition, 1f * Time.deltaTime);
            close = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        close = true;
    }
}
