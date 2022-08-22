using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWind : MonoBehaviour
{
    [SerializeField]
    bool meshSee;

    public Vector3 myCenter;
    public GameObject centerObj;

    public GameObject access;

    // Start is called before the first frame update
    void Start()
    {
        myCenter = GetComponent<Renderer>().bounds.center;

        centerObj = new GameObject("CenterOBJ");
        centerObj.transform.position = myCenter;
        centerObj.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        meshSee = access.GetComponent<accessibilityOptions>().seeWind;

        if (!meshSee)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        transform.RotateAround(centerObj.transform.position, Vector3.up, 10 * Time.deltaTime);

    }
}
