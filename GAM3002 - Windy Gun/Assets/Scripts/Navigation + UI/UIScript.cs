using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //UIness
    public GameObject pauseMenu, accessMenu;
    public bool shallIStop = false;
    public string currentSceneName;

    shootingBullets sb;
    public bool sbActive;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene scenename = SceneManager.GetActiveScene();
        currentSceneName = scenename.name;

        sb = GameObject.FindGameObjectWithTag("Player").GetComponent<shootingBullets>();
    }

    // Update is called once per frame
    void Update()
    {
        sbActive = GameObject.FindGameObjectWithTag("Player").GetComponent<shootingBullets>().active;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shallIStop)
            {
                pauseMenu.SetActive(true);
                shallIStop = false;
                sb.enabled = false;
            }
            else if (!shallIStop)
            {
                pauseMenu.SetActive(false);
                shallIStop = true;
                sb.enabled = sbActive;

            }
        }

        if (accessMenu.activeInHierarchy)
            sb.enabled = false;
    }
}
