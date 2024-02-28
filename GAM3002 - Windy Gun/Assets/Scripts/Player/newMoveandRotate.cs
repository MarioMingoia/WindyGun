using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class newMoveandRotate : MonoBehaviour
{
    public float gravity = -9.81f;


    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 move, look;
    private float lookrotation;

    public GameObject uiStuff;
    public GameObject accessMenu;

    public float originalSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float airMovement;

    [SerializeField]
    private Camera cam;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpingPower = 16f;

    bool isCrouching;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed;

        airMovement = speed / 1.5f;

        sprintSpeed = speed * 1.5f;
        crouchSpeed = speed / 2;
    }
    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void onCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isCrouching)
            {
                print("crouch");
                speed = crouchSpeed;
                isCrouching = false;
            }
            else if (!isCrouching)
            {
                print("un-crouch");
                speed = originalSpeed;
                isCrouching = true;
            }
            //do crouching stuff here
            //else if (context.canceled)
            //{
            //    speed = originalSpeed;
            //    //end crouching stuff here
            //}
        }

    }
    
    public void onLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    
    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jump();
        else if (context.canceled && rb.velocity.y > 0f)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, rb.velocity.z);
    }

    public void onSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = sprintSpeed;
            //do crouching stuff here
        }
        else if (context.canceled)
        {
            speed = originalSpeed;
            //end crouching stuff here
        }
    }


    private void FixedUpdate()
    {
        Move();

        sensitivity = PlayerPrefs.GetInt("sliderSensitivity") / 10;

        if (!IsGrounded())
            speed = airMovement;

        cam.fieldOfView = PlayerPrefs.GetInt("sliderFoV");
    }

    private void LateUpdate()
    {
        camLook();
    }

    void Move()
    {
        Vector3 currentVel = rb.velocity;
        Vector3 targetVel = new Vector3(move.x, 0, move.y);
        targetVel *= speed;

        targetVel = transform.TransformDirection(targetVel);

        Vector3 velChange = (targetVel - currentVel);
        velChange = new Vector3(velChange.x, 0, velChange.z);

        Vector3.ClampMagnitude(velChange, maxForce);

        rb.AddForce(velChange, ForceMode.VelocityChange);
    }

    void camLook()
    {
        print("Horizontal " + PlayerPrefs.GetInt("toggleHorizontal") + " Vertical: " + PlayerPrefs.GetInt("toggleHorizontal"));
        if (!uiStuff.activeInHierarchy && !accessMenu.activeInHierarchy)
        {
            print("inactive");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(Vector3.up * (look.x * PlayerPrefs.GetInt("toggleVertical")) * sensitivity);

            lookrotation += ((-look.y * PlayerPrefs.GetInt("toggleHorizontal"))* sensitivity);
            lookrotation = Mathf.Clamp(lookrotation, -90, 90);
            camHolder.transform.eulerAngles = new Vector3(lookrotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


    }    

    void jump()
    {

        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpingPower, rb.velocity.z);
        }

    }


    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }
}
