using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitcher : MonoBehaviour
{
    public GameObject player;
    public GameObject maincam;
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
                player.GetComponent<movementPlayer>().enabled = false;
                freeCam.SetActive(true);
                maincam.SetActive(false);
                camSwitchBool = false;
            }
            else if (!camSwitchBool)
            {
                player.GetComponent<movementPlayer>().enabled = true;
                freeCam.SetActive(false);
                maincam.SetActive(true);
                camSwitchBool = true;
            }
        }
    }
}
