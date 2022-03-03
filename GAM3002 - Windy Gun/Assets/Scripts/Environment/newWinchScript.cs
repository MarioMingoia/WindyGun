using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWinchScript : MonoBehaviour
{
    public GameObject myCenter;

    public float myStrength;

    public LineRenderer lrnd;

    public GameObject platform;
    public GameObject platformLine;

    public GameObject target;
    public bool windLeft = false;

    public List<GameObject> windy;

    // Start is called before the first frame update
    void Start()
    {
        lrnd = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lrnd.SetPosition(0, myCenter.transform.position);
        lrnd.SetPosition(1, platformLine.transform.position);
        if (myStrength > 0)
        {

            if (!Vector3.Equals(platform.transform.position.y, target.transform.position.y))
            {
                transform.GetChild(0).transform.RotateAround(myCenter.transform.position, transform.right, myStrength * Time.deltaTime);
            }
            platform.transform.localPosition = Vector3.MoveTowards(platform.transform.localPosition, target.transform.localPosition, myStrength / 10 * Time.deltaTime);
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
