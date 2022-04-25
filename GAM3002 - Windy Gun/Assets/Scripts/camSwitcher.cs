using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitcher : MonoBehaviour
{
    public GameObject player;
    public GameObject freeCam;

    bool camSwitchBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (camSwitchBool)
            {
                player.SetActive(false);
                freeCam.SetActive(true);
                camSwitchBool = false;
            }
            else if (!camSwitchBool)
            {
                player.SetActive(true);
                freeCam.SetActive(false);
                camSwitchBool = true;
            }
        }
    }
}
