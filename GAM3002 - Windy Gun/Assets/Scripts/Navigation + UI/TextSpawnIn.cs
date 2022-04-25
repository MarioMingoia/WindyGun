using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnIn : MonoBehaviour
{
    public GameObject spawnIn;
    GameObject spawnInChecker;

    public GameObject buttons;
    public GameObject endpoint;

    float speed = 2f;
    float slowSpeed;
    // Start is called before the first frame update
    private void Start()
    {
        slowSpeed = speed / 2;
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            if (transform.childCount <= 0)
            {
                GameObject textObj = Instantiate(spawnIn, transform.position, Quaternion.identity);
                textObj.transform.parent = transform;
                spawnInChecker = textObj;
            }

            if (spawnInChecker != null)
            {
                spawnInChecker.transform.position = Vector3.MoveTowards(spawnInChecker.transform.position, endpoint.transform.position, speed);
                if (Vector3.Distance(spawnInChecker.transform.position, endpoint.transform.position) <= 1f)
                {
                    Destroy(spawnInChecker);
                }
                //checks global position by adding the position of the spawn in point and text
                else if ((spawnInChecker.transform.position.x + transform.position.x) >= 0)
                { 
                    buttons.SetActive(true);

                speed = Mathf.Lerp(speed, slowSpeed, Time.deltaTime);

                }
            }
        }
        catch
        {

        }

    }
}
