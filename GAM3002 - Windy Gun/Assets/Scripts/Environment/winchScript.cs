using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winchScript : MonoBehaviour
{

    public GameObject myCenter;

    public float myStrength;

    public LineRenderer lrnd;

    public GameObject platform;
    public GameObject platformLine;

    public GameObject target;
    public bool windLeft = false;

    public Vector3 platOriginalPos;

    public List<GameObject> windy;

    // Start is called before the first frame update
    void Start()
    {
        lrnd = GetComponent<LineRenderer>();
        try
        {
            platOriginalPos = platform.transform.position;
        }
        catch
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (platformLine)
        {
            lrnd.enabled = true;
            lrnd.SetPosition(0, myCenter.transform.position);
            lrnd.SetPosition(1, platformLine.transform.position);
        }
        else
        {
            lrnd.enabled = false;
        }
        if (myStrength > 0)
        {

            if (!Vector3.Equals(platform.transform.position.y, target.transform.position.y))
            {
                transform.GetChild(0).transform.RotateAround(myCenter.transform.position, transform.right, myStrength * 2 * Time.deltaTime);
            }
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, target.transform.position, myStrength * Time.deltaTime);
        }

        for (int i = 0; i < windy.Count; i++)
        {
            if (windy[i] == null)
            {
                windy.RemoveAt(i);
                windLeft = true;
                myStrength = 0;
            }
        }

        if (windLeft == true && windy.Count <= 0 && myStrength <= 0)
        {
            transform.GetChild(0).transform.RotateAround(myCenter.transform.position, transform.right, -15 * Time.deltaTime);
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, platOriginalPos, 15 * Time.deltaTime);

            if (Vector3.Equals(platform.transform.position, platOriginalPos))
                windLeft = false;

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("WindArea"))
        {
            myStrength = other.gameObject.GetComponent<windArea>().strength;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("WindArea"))
        {
            windy.Add(other.gameObject);
            windLeft = false;
        }
    }

}
