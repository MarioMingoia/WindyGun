using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsMenus : MonoBehaviour
{
    public bool panelEnabled = false;
    public GameObject myPanel;
    public List<GameObject> otherPanels;

    public void ChangeSettingPanel()
    {
        panelEnabled = !panelEnabled;

        myPanel.SetActive(panelEnabled);

        for (int i = 0; i < otherPanels.Count; i++)
        {
            if (otherPanels[i].activeInHierarchy)
            {
                myPanel.SetActive(otherPanels[i].activeSelf);
            }
            otherPanels[i].SetActive(false);
        }
    }
}
