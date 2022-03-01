using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnIn : MonoBehaviour
{
    public GameObject spawnIn;
    public GameObject spawnInChecker;

    public GameObject buttons;
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
                spawnInChecker.transform.Translate(1, 0, 0);
                if (spawnInChecker.transform.localPosition.x >= 1250)
                {
                    Destroy(spawnInChecker);
                }
                //checks global position by adding the position of the spawn in point and text
                else if ((spawnInChecker.transform.position.x + transform.position.x) >= 0)
                {
                    buttons.SetActive(true);

                }
            }
        }
        catch
        {

        }

    }
}
