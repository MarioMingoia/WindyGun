using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textEnabler : MonoBehaviour
{
    public List<GameObject> txt;

    public int indexPos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            txt.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < txt.Count; i++)
        {
            if (i != 0)
            {
                txt[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (txt[indexPos].activeInHierarchy)
        {
            return;
        }
        else if (!txt[indexPos].activeInHierarchy)
        {
            indexPos += 1;
        }

        txt[indexPos].SetActive(true);
    }
}
