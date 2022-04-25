using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freecam : MonoBehaviour
{
    Vector2 mouseLook;

    Vector2 smoothV;

    public float XAxisSensitivity = 5.0f;
    public float YAxisSensitivity = 5.0f;
    private float _rotationX;
    [Range(0, 89)] public float MaxXAngle = 60f;

    public float smoothing = 2.0f;

    public float speed;

    public GameObject uiStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraLook();
        movement(speed);
    }

    void cameraLook()
    {
        if (!uiStuff.activeInHierarchy)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            var rotationHorizontal = XAxisSensitivity * Input.GetAxis("Mouse X");
            var rotationVertical = YAxisSensitivity * Input.GetAxis("Mouse Y");

            //applying mouse rotation
            // always rotate Y in global world space to avoid gimbal lock
            transform.Rotate(Vector3.up * rotationHorizontal, Space.World);

            var rotationY = transform.localEulerAngles.y;

            _rotationX += rotationVertical;
            _rotationX = Mathf.Clamp(_rotationX, -MaxXAngle, MaxXAngle);

            transform.localEulerAngles = new Vector3(-_rotationX, rotationY, 0);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void movement(float flMove)
    {
        transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * flMove) * Time.deltaTime);
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * flMove) * Time.deltaTime);
    }
}
