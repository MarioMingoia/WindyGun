using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnIn : MonoBehaviour
{
    public GameObject objtoSpawn;
    public GameObject spawnPos;

    public float countdown;
    private float myCountdown;
    bool startSpawn;

    private void Start()
    {
        myCountdown = countdown;
    }
    // Update is called once per frame
    void Update()
    {
        if (startSpawn)
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
        if (other.gameObject.CompareTag("Player"))
            startSpawn = true;
    }

}
