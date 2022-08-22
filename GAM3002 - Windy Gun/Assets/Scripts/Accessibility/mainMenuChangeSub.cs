using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class mainMenuChangeSub : MonoBehaviour
{

    public Texture original;
    public Texture alpha;

    public float cd;
    float myCd;
    // Start is called before the first frame update
    void Start()
    {
        myCd = cd;
    }

    // Update is called once per frame
    void Update()
    {
        int randomNum = Random.Range(0, 10);

        if (cd > 0)
            cd -= Time.deltaTime;

        if (cd <= 0)
        {
            if (randomNum % 2 == 0)
            {
                GetComponent<RawImage>().texture = original;
                cd = myCd;
            }
            else
            {
                GetComponent<RawImage>().texture = alpha;
                cd = myCd;
            }
        }
    }
}
