using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gliderPillar : MonoBehaviour
{
    public Vector3 myCenter;
    public GameObject plrGlider;

    GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        myCenter = GetComponent<Renderer>().bounds.center;
        center = new GameObject("centerPt");
        center.transform.position = myCenter;
        center.transform.parent = gameObject.transform;
        plrGlider = GameObject.FindGameObjectWithTag("Player").GetComponent<glider>().gliderObj;

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).RotateAround(center.transform.position, Vector3.up, 10 * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            plrGlider.SetActive(true);
            other.gameObject.GetComponent<glider>().enabled = true;
        }
    }
}
