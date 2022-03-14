using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int middleChild = other.transform.childCount / 2;
            DontDestroyOnLoad(other.gameObject);
            other.transform.GetChild(middleChild).GetComponent<mainMenu>().nextScene();
        }
    }
}
