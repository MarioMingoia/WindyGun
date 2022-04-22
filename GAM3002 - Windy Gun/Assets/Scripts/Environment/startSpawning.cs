using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSpawning : MonoBehaviour
{

    public GameObject objtoSpawn;
    public GameObject spawnPos;
    public string triggerTag;
    public bool startSpawningBool;

    public float countdown;
    private float myCountdown;

    bool ontrigger;

    private void Start()
    {
        myCountdown = countdown;
    }

    private void Update()
    {
        if (ontrigger && startSpawningBool)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }

            if (countdown <= 0)
            {
                Instantiate(objtoSpawn, spawnPos.transform.position, Quaternion.identity, null);
                countdown = myCountdown;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
            ontrigger = true;
    }
}
