using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnIn : MonoBehaviour
{
    public GameObject spawnIn;
    GameObject spawnInChecker;

    public GameObject buttons;
    public GameObject endpoint;
    public GameObject midPt;

    float speed = .5f;
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
                textObj.transform.SetParent(transform, false);
                spawnInChecker = textObj;
            }

            if (spawnInChecker != null)
            {

                spawnInChecker.transform.position = Vector3.MoveTowards(spawnInChecker.transform.position, endpoint.transform.position, speed);
                if (Vector3.Distance(spawnInChecker.transform.position, endpoint.transform.position) <= 0.001f)
                {
                    Destroy(spawnInChecker);
                }
                else if (Vector3.Distance(spawnInChecker.transform.position, midPt.transform.position) <= 5f)
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
