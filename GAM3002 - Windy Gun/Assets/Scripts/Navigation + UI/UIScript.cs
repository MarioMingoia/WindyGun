using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;

public class UIScript : MonoBehaviour
{
    //UIness
    public GameObject pauseMenu, accessMenu;
    public bool shallIStop = false;
    public string currentSceneName;

    public bool sbActive;

    public PlayerInput plrinputSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene scenename = SceneManager.GetActiveScene();
        currentSceneName = scenename.name;

        plrinputSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        sbActive = GameObject.FindGameObjectWithTag("Player").GetComponent<shootingBullets>().active;

        if (accessMenu.activeInHierarchy)
            plrinputSystem.enabled = false;
    }

    public void closeMenu()
    {
        if (shallIStop)
        {
            pauseMenu.SetActive(true);
            shallIStop = false;

            plrinputSystem.enabled = false;
        }
        else if (!shallIStop)
        {
            pauseMenu.SetActive(false);
            shallIStop = true;

            plrinputSystem.enabled = true;


        }
    }
}
