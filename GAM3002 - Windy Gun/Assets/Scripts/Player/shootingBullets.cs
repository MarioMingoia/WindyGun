using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.InputSystem;

public class shootingBullets : MonoBehaviour
{
    public Text ammoCount;

    public int ammo;
    public int fullAmmo;

    public GameObject firePos;
    public GameObject gun;
    public GameObject bullet;

    public GameObject cam;

    int minimum = 1;
    int max = 5;
    float sensitivity = 1.0f;
    float app = 1;
    float chargeUp = 1;
    bool isDown = false;

    public Rigidbody rb;

    public float countdown;
    private float myCountdown;

    Quaternion overallRot;
    int intapp = 1;
    
    public List<GameObject> amtofWind;

    public int windMultiplyer;
    public bool recall;
    bool canRecall;

    public Text strengthDis;

    public bool active;

    GameObject access;

    public void onShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (ammo > 0)
            {
                isDown = true;
                countdown = myCountdown;
            }
        }

        if (context.canceled)
        {
            if (ammo > 0)
            {
                shooting(false, " don't Rotate");
            }
        }    
    }
    public void onChangeSizeofWind(InputAction.CallbackContext context)
    {
        app += (context.ReadValue<Vector2>().y / 120) * sensitivity;
        app = Mathf.Clamp(app, minimum, ammo);
        intapp = Mathf.RoundToInt(app);
    }
    public void onRecall(InputAction.CallbackContext context)
    {
        canRecall = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        fullAmmo = ammo;

        cam = Camera.main.gameObject;

        rb = GetComponent<Rigidbody>();

        myCountdown = countdown;
        countdown = 0;

        recall = false;

        firePos.SetActive(true);
        gun.SetActive(true);

        active = gameObject.GetComponent<shootingBullets>().enabled;

        access = transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (recall)
        {
            for (int i = 0; i < amtofWind.Count; i++)
            {
                Destroy(amtofWind[i]);
                ammo += Mathf.RoundToInt(amtofWind[i].transform.localScale.x);
                amtofWind.RemoveAt(i);
            }
            if (amtofWind.Count <= 0)
                recall = false;
        }

        if (isDown)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                chargeUp += 1;
                chargeUp = Mathf.Clamp(chargeUp, minimum, max);
                countdown = myCountdown;
            }
        }
        else
        {
            chargeUp = 1;
        }

        strengthDis.text = chargeUp.ToString();

        overallRot = Quaternion.Euler(cam.transform.localEulerAngles.x, transform.eulerAngles.y, 0) ;
        

        if (ammo > fullAmmo)
        {
            ammo = fullAmmo;
        }
        ammo = Mathf.Clamp(ammo, 0, fullAmmo);
        ammoCount.text = (ammo + " / " + fullAmmo).ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Chests"))
        {
            if (other.gameObject.GetComponent<openChest>().enabled == false && other.gameObject.GetComponent<openChest>().refillPoint >= 0)
            {
                recall = true;
                other.gameObject.GetComponent<openChest>().enabled = true;
                fullAmmo = other.gameObject.GetComponent<openChest>().refillPoint;
                ammo = fullAmmo;
                
           }
            else if (other.gameObject.GetComponent<openChest>().refillPoint <= 0)
            {
                if(canRecall)
                {
                    recall = true;
                }
            }

        }
    }

    void shooting(bool settoRotate, string nameofMine)
    {
        isDown = false;
        GameObject goBullet = Instantiate(bullet, firePos.transform.position, overallRot);
        goBullet.transform.localScale = new Vector3(intapp, intapp, goBullet.transform.localScale.z);
        goBullet.AddComponent<stopWind>();
        goBullet.GetComponent<Rigidbody>().AddForce(firePos.transform.forward * 1000);

        Vector3 force = transform.position + goBullet.transform.position;

        goBullet.GetComponent<windArea>().strength = chargeUp * windMultiplyer;

        goBullet.name = goBullet.name.Replace("(Clone)", nameofMine);
        amtofWind.Add(goBullet);

        if (chargeUp > 1)
        {
            rb.AddForce(force.normalized * -(chargeUp * 2 * 50));
        }

        if (!access.GetComponent<accessibilityOptions>().isInfinite)
            ammo -= intapp;

        intapp = 1;


    }
}
