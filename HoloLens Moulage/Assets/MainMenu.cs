using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;

public class MainMenu : MonoBehaviour { 

    public GameObject panel;
    private Transform currentPanel;

    public void openMenu()
    {
        this.gameObject.SetActive(false);
        currentPanel = panel.transform.Find("Main");
        currentPanel.gameObject.SetActive(true);
    }

    public void openWound(Button btn)
    {
        clearActivePanel();
        if(btn.name.Equals("Gunshot"))
        {
            panel.transform.Find("GunshotOption").gameObject.SetActive(true);
        } else if (btn.name.Equals("Stab"))
        {
            panel.transform.Find("StabOption").gameObject.SetActive(true);
        } else if (btn.name.Equals("Slash"))
        {
            panel.transform.Find("SlashOption").gameObject.SetActive(true);
        }
    }

    public void clearActivePanel()
    {
        panel.transform.Find("GunshotOption").gameObject.SetActive(false);
        panel.transform.Find("StabOption").gameObject.SetActive(false);
        panel.transform.Find("SlashOption").gameObject.SetActive(false);
    }

  
}
