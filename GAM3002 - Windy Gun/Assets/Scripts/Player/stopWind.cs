using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopWind : MonoBehaviour
{
    public bool collided;
    Collider coll;
    public Vector3 startPoint;

    public int projectileRange = 10;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        float dis = Vector3.Distance(transform.position, startPoint);
        if (collided == true || dis >= projectileRange)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            coll.isTrigger = true;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            collided = true;
        }
    }
}
