using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyaccessmenu : MonoBehaviour
{ 
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.transform.parent = GameObject.Find("Canvas").transform;

        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;

    }
}
