using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvedTriggerZones : MonoBehaviour
{
    public List<GameObject> otherTriggerZone;

    [SerializeField]
    List<GameObject> myWind;

    [SerializeField]
    List<windArea> myWindArea;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            myWind.Add(transform.GetChild(0).gameObject);
        }

        foreach (GameObject x in myWind)
        {
            myWindArea.Add(x.transform.GetChild(4).GetComponent<windArea>());

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            print("123");

            GameObject plrWind = other.gameObject;

            foreach (GameObject x in myWind)
            {
                x.SetActive(true);
                x.transform.localScale = new Vector3(0.1506474f, plrWind.transform.localScale.y, 1.498941f);
            }

            foreach (windArea x in myWindArea)
            {
                x.strength = plrWind.GetComponent<windArea>().strength;

            }

            foreach (GameObject x in otherTriggerZone)
            {
                x.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            foreach (GameObject x in myWind)
            {
                x.SetActive(false);
                x.transform.localScale = new Vector3(0.1506474f, 0.1462381f, 1.498941f);
            }

            foreach (windArea x in myWindArea)
            {
                x.strength = 1;

            }
            foreach (GameObject x in otherTriggerZone)
            {
                x.SetActive(true);
            }
        }
    }
}
