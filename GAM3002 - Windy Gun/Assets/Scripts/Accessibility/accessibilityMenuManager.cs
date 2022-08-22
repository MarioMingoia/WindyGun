using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accessibilityMenuManager : MonoBehaviour
{

    public GameObject accessMenu;
    public GameObject originalMenu;
    public GameObject wind;
    private void Start()
    {
    }
    public void openAccessMenu()
    {
        accessMenu.SetActive(true);
        originalMenu.SetActive(false);

        try
        {
            wind.SetActive(true);

        }
        catch
        {
        }
    }

    public void closeAccessMenu()
    {
        accessMenu.SetActive(false);
        originalMenu.SetActive(true);

        try
        {
            wind.SetActive(false);
        }
        catch
        {
        }
    }
}
