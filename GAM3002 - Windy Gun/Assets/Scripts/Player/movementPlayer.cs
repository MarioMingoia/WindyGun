using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    // movement
    public float speed;
    public float originalSpeed;

    // Jump
    public float jumpForce;
    public float airMovement;
    public bool grounded;
    public Rigidbody rb;
    public bool readytoJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        airMovement = speed / 1.5f;
        originalSpeed = speed;


    }

    // Update is called once per frame
    void Update()
    {
        //sprint
        if (Input.GetKeyDown(KeyCode.LeftControl))
            speed *= 1.5f;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            speed = originalSpeed;


        if (grounded)
        {
            movement(speed);
        }
        else
        {
            movement(airMovement);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            readytoJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (grounded && readytoJump && Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.velocity = Vector3.up * jumpForce * Time.deltaTime;
            grounded = false;
        }
    }
    void movement(float flMove)
    {
        transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * flMove) * Time.deltaTime);
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * flMove) * Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            ContactPoint cp = collision.contacts[0];

            if (cp.point.y < transform.position.y)
            {
                grounded = true;
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            grounded = false;

            readytoJump = false;
        }
    }

   


}
