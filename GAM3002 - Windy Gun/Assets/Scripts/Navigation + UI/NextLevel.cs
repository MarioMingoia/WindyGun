using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int middleChild = 0;

            for (int i = 0; i < other.transform.childCount; i++)
            {
                if (other.transform.GetChild(i).name.Contains("ScriptController"))
                {
                    middleChild = i;    
                }
            }
            
            DontDestroyOnLoad(other.gameObject);
            other.transform.GetChild(middleChild).GetComponent<mainMenu>().nextScene();
        }
    }
}
