using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class newMoveandRotate : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 move, look;
    private float lookrotation;
    public bool grounded;

    public GameObject uiStuff;
    public GameObject accessMenu;

    public float originalSpeed;
    public float sprintSpeed;
    public float airMovement;

    [SerializeField]
    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed;

        airMovement = speed / 1.5f;

        sprintSpeed = speed * 1.5f;
    }
    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    
    public void onLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    
    public void onJump(InputAction.CallbackContext context)
    {
        jump();
    }
    
    public void onSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = sprintSpeed;

        }
        else if (context.canceled)
        {
            speed = originalSpeed;
        }
    }


    private void FixedUpdate()
    {
        Move();

        sensitivity = PlayerPrefs.GetInt("sliderSensitivity") / 10;

        if (!grounded)
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

        if (!uiStuff.activeInHierarchy && !accessMenu.activeInHierarchy)
        {
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
        Vector3 jumpForces = Vector3.zero;

        if (grounded)
        {
            jumpForces = Vector3.up * jumpForce;
        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }


    public void setGrounded(bool state)
    {
        grounded = state;
    }
}
