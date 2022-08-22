using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class accessibilityOptions : MonoBehaviour
{
    [Header("Misc Accessibility options")]
    public bool seeWind;
    public Toggle windToggle;
    public GameObject subtitles;
    public Toggle subToggle;

    [Header("Colourblindness toggles")]
    //colourblind options
    public Toggle defaultToggle;
    public Toggle protanopiaToggle;
    public Toggle deuteranopiaToggle;
    public Toggle tritanopiaToggle;
    public Toggle monochromacyToggle;

    [Header("ColourBlindess effect Leaves Sprites")]
    public Material defaultSprite;
    public Material protanopiaSprite;
    public Material deuteranopiaSprite;
    public Material tritanopiaSprite;
    public Material monochromacySprite;

    [Header("ColourBlindess for rest of materials used")]
    public Material crate;
    public Material glider;
    public Material wire;
    public Material actieWire;
    public Material player;
    public Material wind;

    [Header("Crate Colours")]
    public Color crateOriginal;
    public Color crateProtan;
    public Color crateDeutan;
    public Color crateTritan;
    public Color crateMono;
    
    [Header("Glider Colours")]
    public Color gliderOriginal;
    public Color gliderProtan;
    public Color gliderDeutan;
    public Color gliderTritan;
    public Color gliderMono;
    
    [Header("Wire Colours")]
    public Color wireOriginal;
    public Color wireProtan;
    public Color wireDeutan;
    public Color wireTritan;
    public Color wireMono;
    
    [Header("Active Wire Colours")]
    public Color acwireOriginal;
    public Color acwireProtan;
    public Color acwireDeutan;
    public Color acwireTritan;
    public Color acwireMono;
    
    [Header("Player Colours")]
    public Color playerOriginal;
    public Color playerProtan;
    public Color playerDeutan;
    public Color playerTritan;
    public Color playerMono;
    
    [Header("Wind Colours")]
    public Color windOriginal;
    public Color windProtan;
    public Color windDeutan;
    public Color windTritan;
    public Color windMono;
    void Start()
    {
        //player prefs store preferences of player between sessions
        if (PlayerPrefs.GetInt("ToggleBool") == 1)
            defaultToggle.isOn = true;
        else
            defaultToggle.isOn = false;
        
        if (PlayerPrefs.GetInt("ToggleBool2") == 1)
            protanopiaToggle.isOn = true;
        else
            protanopiaToggle.isOn = false;
        
        if (PlayerPrefs.GetInt("ToggleBool3") == 1)
            deuteranopiaToggle.isOn = true;
        else
            deuteranopiaToggle.isOn = false;
        
        if (PlayerPrefs.GetInt("ToggleBool4") == 1)
            tritanopiaToggle.isOn = true;
        else
            tritanopiaToggle.isOn = false;
        
        if (PlayerPrefs.GetInt("ToggleBool5") == 1)
            monochromacyToggle.isOn = true;
        else
            monochromacyToggle.isOn = false;
        
        if (PlayerPrefs.GetInt("ToggleBool6") == 1)
            windToggle.isOn = true;
        else
            windToggle.isOn = false; 
        
        if (PlayerPrefs.GetInt("ToggleBool7") == 1)
            subToggle.isOn = true;
        else
            subToggle.isOn = false;
        
    }

    private void Update()
    {
        playerPrefsCB();
        spriteandMat();

        switchWind();
        switchSub();

    }

    public void spriteandMat()
    {
        if (PlayerPrefs.GetInt("ToggleBool") == 1)
        {
            foreach (ParticleSystem obj in Object.FindObjectsOfType(typeof(ParticleSystem)))
            {
                obj.GetComponent<ParticleSystemRenderer>().material = defaultSprite;
            }

            crate.SetColor("_Color", crateOriginal);
            glider.SetColor("_Color", gliderOriginal);
            wire.SetColor("_Color", wireOriginal);
            actieWire.SetColor("_Color", acwireOriginal);
            player.SetColor("_Color", playerOriginal);
            player.SetColor("_EmissionColor", playerOriginal);
            wind.SetColor("_Color", windOriginal);
        }

        if (PlayerPrefs.GetInt("ToggleBool2") == 1)
        {
            foreach (ParticleSystem obj in Object.FindObjectsOfType(typeof(ParticleSystem)))
            {
                obj.GetComponent<ParticleSystemRenderer>().material = protanopiaSprite;
            }

            crate.SetColor("_Color", crateProtan);
            glider.SetColor("_Color", gliderProtan);
            wire.SetColor("_Color", wireProtan);
            actieWire.SetColor("_Color", acwireProtan);
            player.SetColor("_Color", playerProtan);
            player.SetColor("_EmissionColor", playerProtan);
            wind.SetColor("_Color", windProtan);

        }
        if (PlayerPrefs.GetInt("ToggleBool3") == 1)
        {
            foreach (ParticleSystem obj in Object.FindObjectsOfType(typeof(ParticleSystem)))
            {
                obj.GetComponent<ParticleSystemRenderer>().material = deuteranopiaSprite;
            }

            crate.SetColor("_Color", crateDeutan);
            glider.SetColor("_Color", gliderDeutan);
            wire.SetColor("_Color", wireDeutan);
            actieWire.SetColor("_Color", acwireDeutan);
            player.SetColor("_Color", playerDeutan);
            player.SetColor("_EmissionColor", playerDeutan);
            wind.SetColor("_Color", windDeutan);

        }

        if (PlayerPrefs.GetInt("ToggleBool4") == 1)
        {
            foreach (ParticleSystem obj in Object.FindObjectsOfType(typeof(ParticleSystem)))
            {
                obj.GetComponent<ParticleSystemRenderer>().material = tritanopiaSprite;
            }

            crate.SetColor("_Color", crateTritan);
            glider.SetColor("_Color", gliderTritan);
            wire.SetColor("_Color", wireTritan);
            actieWire.SetColor("_Color", acwireTritan);
            player.SetColor("_Color", playerTritan);
            player.SetColor("_EmissionColor", playerTritan);
            wind.SetColor("_Color", windTritan);

        }
        if (PlayerPrefs.GetInt("ToggleBool5") == 1)
        {
            foreach (ParticleSystem obj in Object.FindObjectsOfType(typeof(ParticleSystem)))
            {
                obj.GetComponent<ParticleSystemRenderer>().material = monochromacySprite;
            }

            crate.SetColor("_Color", crateMono);
            glider.SetColor("_Color", gliderMono);
            wire.SetColor("_Color", wireMono);
            actieWire.SetColor("_Color", acwireMono);
            player.SetColor("_Color", playerMono);
            player.SetColor("_EmissionColor", playerMono);
            wind.SetColor("_Color", windMono);

        }
    }

    public void playerPrefsCB()
    {
        if (defaultToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool", 1);
        else
            PlayerPrefs.SetInt("ToggleBool", 0);

        if (protanopiaToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool2", 1);
        else
            PlayerPrefs.SetInt("ToggleBool2", 0);

        if (deuteranopiaToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool3", 1);
        else
            PlayerPrefs.SetInt("ToggleBool3", 0);

        if (tritanopiaToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool4", 1);
        else
            PlayerPrefs.SetInt("ToggleBool4", 0);
        
        if (monochromacyToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool5", 1);
        else
            PlayerPrefs.SetInt("ToggleBool5", 0);
    }
    public void switchWind()
    {
        if (windToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool6", 1);
        else
            PlayerPrefs.SetInt("ToggleBool6", 0);

        if (PlayerPrefs.GetInt("ToggleBool6") == 1)
            seeWind = true;
        else
            seeWind = false;
    }

    public void switchSub()
    {


        if (subToggle.isOn == true)
            PlayerPrefs.SetInt("ToggleBool7", 1);
        else
            PlayerPrefs.SetInt("ToggleBool7", 0);

        if (PlayerPrefs.GetInt("ToggleBool7") == 1)
            subtitles.SetActive(true);
        else
            subtitles.SetActive(false);
    }
}
