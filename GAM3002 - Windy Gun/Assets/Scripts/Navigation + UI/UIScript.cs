using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //UIness
    public GameObject pauseMenu;
    public bool shallIStop = false;
    public string currentSceneName;

    shootingBullets sb;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shallIStop)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                shallIStop = false;
                sb.enabled = false;
            }
            else if (!shallIStop)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                shallIStop = true;
                sb.enabled = true;

            }
        }
    }
}
