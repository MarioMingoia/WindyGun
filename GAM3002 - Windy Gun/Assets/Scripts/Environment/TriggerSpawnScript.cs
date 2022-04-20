using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnScript : MonoBehaviour
{

    public GameObject plateCube;
    public GameObject spawnPos;

    private void Start()
    {
        GameObject gobj = Instantiate(plateCube, spawnPos.transform.position, Quaternion.identity);
        gobj.transform.parent = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlateCube"))
        {
            Destroy(other.gameObject);
            StartCoroutine(waitforSpawn());
        }
    }

    IEnumerator waitforSpawn()
    {
        yield return new WaitForSeconds(5);
        GameObject gobj = Instantiate(plateCube, spawnPos.transform.position, Quaternion.identity);
        gobj.transform.parent = null;
    }
}
