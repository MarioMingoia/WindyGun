using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnIn : MonoBehaviour
{
    public GameObject spawnIn;
    GameObject spawnInChecker;

    public GameObject buttons;
    public GameObject endpoint;

    float speed = 0.75f;
    // Start is called before the first frame update

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
                spawnInChecker.transform.position = Vector3.MoveTowards(spawnInChecker.transform.position, endpoint.transform.position, .5f);
                if (Vector3.Distance(spawnInChecker.transform.position, endpoint.transform.position) <= 1f)
                {
                    Destroy(spawnInChecker);
                }
                //checks global position by adding the position of the spawn in point and text
                else if ((spawnInChecker.transform.position.x + transform.position.x) >= 0)
                { 
                    buttons.SetActive(true);

                speed = Mathf.Lerp(speed, 0.5f, Time.deltaTime);

                }
            }
        }
        catch
        {

        }

    }
}
