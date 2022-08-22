using System.Collections;
using System.Collections.Generic;
using UnityEngine;




using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    bool gunena, gliderena;
    int ammoamount, maxammo;
    Vector3 pos;

    public string startScenName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startScenName == "MainMenu" && this.transform.parent == null)
        {

            GameObject plr = GameObject.Find("player");

            plr.transform.position = pos;

            plr.GetComponent<shootingBullets>().enabled = gunena;
            plr.GetComponent<shootingBullets>().ammo = ammoamount;
            plr.GetComponent<shootingBullets>().fullAmmo = maxammo;
            plr.GetComponent<glider>().enabled = gliderena;

            startScenName = "";
            Destroy(gameObject);
        }
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        data.currentScene = SceneManager.GetActiveScene().name;
        data.hasGun = transform.GetComponentInParent<shootingBullets>().active;
        data.ammo = transform.GetComponentInParent<shootingBullets>().ammo;
        data.maxAmmo = transform.GetComponentInParent<shootingBullets>().fullAmmo;
        data.hasGlider = transform.GetComponentInParent<glider>().active;
        print(data.hasGlider);
        print(data.hasGun);

        data.x = transform.parent.position.x;
        data.y = transform.parent.position.y;
        data.z = transform.parent.position.z;


        bf.Serialize(file, data);
        file.Close();

    }

    public void load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            startScenName = SceneManager.GetActiveScene().name;

            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(data.currentScene);

            gunena = data.hasGun;
            gliderena = data.hasGlider;

            ammoamount = data.ammo;
            maxammo = data.maxAmmo;
            pos = new Vector3(data.x, data.y, data.z);
        }
    }
}


[Serializable]
class PlayerData
{
    public string currentScene;
    public bool hasGun;
    public int ammo;
    public int maxAmmo;
    public bool hasGlider;


    public float x;
    public float y;
    public float z;
}

