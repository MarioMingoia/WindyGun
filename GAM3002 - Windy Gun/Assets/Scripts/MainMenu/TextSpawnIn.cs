using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnIn : MonoBehaviour
{
    public GameObject spawnIn;
    public GameObject spawnInChecker;
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
                spawnInChecker.transform.Translate(.75f, 0, 0);
                if (spawnInChecker.transform.position.x >= 642)
                {
                    Destroy(spawnInChecker);
                }
            }
        }
        catch
        {

        }

    }
}
