using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWall : MonoBehaviour
{
    bool destroy = false;

    public string collisionTag;

    public bool shatter;
    private void Update()
    {
        try
        {

            if (destroy)
            {

                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject explosive = transform.GetChild(i).gameObject;
                    transform.GetChild(i).parent = null;

                    if (shatter)
                    {
                        Destroy(explosive);
                    }

                    explosive.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeAll;
                    explosive.GetComponent<BoxCollider>().enabled = true;
                    explosive.GetComponent<Rigidbody>().AddExplosionForce(5, transform.position, 50, 3);
                }
                if (transform.childCount <= 0)
                {
                    Destroy(gameObject);
                    destroy = false;
                }
            }
        }
        catch
        {

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains(collisionTag))
        {
            if (collision.gameObject.GetComponent<abilityToDestroy>().canDestroy)
            {
                destroy = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains(collisionTag))
        {
            if (other.gameObject.GetComponent<abilityToDestroy>().canDestroy)
                destroy = true;
        }
    }
}
