using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windScaling : MonoBehaviour
{
    public bool startShrinking;
    public bool raycastCheck;
    Vector3 originalSize;
    Vector3 newSize;
    Vector3 originalPos;
    public GameObject rayFrom;

    public List<string> tagstoAvoid;

    float distanceMax;

    public LayerMask ignoreMe;

    [SerializeField]
    Vector3 dir;
    [SerializeField]
    Vector3 scaleDir;


    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale;
        originalPos = transform.position;

        distanceMax = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        racyastStuff();
        if (startShrinking && raycastCheck)
        {
            Resize(-1f, dir, scaleDir);
        }
        else if (!raycastCheck)
        {
            if (transform.localScale.z <= distanceMax)
                Resize(1f, dir, scaleDir);
        }
    }

    void racyastStuff()
    {
        Debug.DrawRay(rayFrom.transform.position, transform.forward * distanceMax, Color.green);

        Ray ray = new Ray(rayFrom.transform.position, transform.forward * distanceMax);
        //has the ray go from the front of the player
        RaycastHit hit;

        raycastCheck = Physics.Raycast(ray, out hit, distanceMax, ~ignoreMe);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!tagstoAvoid.Contains(other.gameObject.tag))
        {
            startShrinking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        startShrinking = false;
    }

    public void Resize(float amount, Vector3 direction, Vector3 scaleDirection)
    {
        //moves in negative direction by amount divided by 2
        //divided by 2 as scale is applied in both positive and negative direction
        transform.position -= direction * amount / 2;
        // Scale object in the specific direction
        transform.localScale -= scaleDirection * amount; 
    }
}
