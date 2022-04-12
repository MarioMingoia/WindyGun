using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glider : MonoBehaviour
{
    public GameObject gliderObj;
    public bool gliderActive;

    public float fallSpeed = 2;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        gliderObj.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gliderObj.SetActive(gliderActive);

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (gliderActive)
                gliderActive = false;
            else if (!gliderActive)
                gliderActive = true;


        }
    }

    private void FixedUpdate()
    {
        if (gliderActive && rb.velocity.y <= 0)
        {
            rb.velocity += Vector3.up * fallSpeed;
        }

    }
}
