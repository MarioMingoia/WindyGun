using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatPlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).LookAt(new Vector3(2 * transform.GetChild(0).position.x - player.transform.position.x, transform.GetChild(0).position.y, 2 * transform.GetChild(0).position.z - player.transform.position.z));

        //transform.GetChild(0).rotation = Quaternion.LookRotation(transform.GetChild(0).position - player.transform.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player.tag))
        {
            gameObject.SetActive(false);           
        }
    }
}
