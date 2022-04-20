using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class glider : MonoBehaviour
{
    public GameObject gliderObj;
    public bool gliderActive;

    public float fallSpeed = 2;

    public Rigidbody rb;

    public float countdown;
    public float myCD;
    public bool startCD;

    public GameObject sliderDisplay;
    public Slider sld;

    bool startIncrease;

    movementPlayer mp;

    // Start is called before the first frame update
    void Start()
    {
        gliderObj.SetActive(false);
        rb = GetComponent<Rigidbody>();
        myCD = countdown;

        mp = GetComponent<movementPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown = Mathf.Clamp(countdown, 0, myCD);

        gliderObj.SetActive(gliderActive);
        sliderDisplay.SetActive(gliderActive);

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (gliderActive)
                gliderActive = false;
            else if (!gliderActive)
                gliderActive = true;
        }

        if (startIncrease)
        {
            if (countdown < myCD)
            {
                countdown += 0.05f;
            }
        }
    }

    private void FixedUpdate()
    {

        sld.value = countdown / myCD;

        if (gliderActive && !Mathf.Approximately(rb.velocity.y, 0))
        {
            startIncrease = false;

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * fallSpeed;
                mp.airMovement = 5;
                startCD = true;
            }
            else
            {
                startCD = false;
            }
        }
        else
        {
            startCD = false;
            mp.airMovement = 0;
        }

        if (startCD)
        {
            if (countdown > 0)
                countdown -= Time.deltaTime;

            else if (countdown <= 0)
            {
                startCD = false;
                gliderActive = false;
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            ContactPoint cp = collision.contacts[0];

            if (cp.point.y < transform.position.y)
            {
                startIncrease = true;
            }
        }
    }
}
