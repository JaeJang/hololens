using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMenu : MonoBehaviour {

    public GameObject panel;
    private Button currentButton;
    private Transform currentPanel;
    
	// Use this for initialization
	void Start () {
        currentPanel = panel.transform.Find("GunshotPanel");
        currentPanel.gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickButton(Button btn)
    {

        currentPanel.gameObject.SetActive(false);
        if (btn.name.Equals("GunshotType"))
        {
            currentPanel = panel.transform.Find("GunshotPanel");

        }
        if (btn.name.Equals("SlashType"))
        {
            currentPanel = panel.transform.Find("SlashPanel");
        }
        if (btn.name.Equals("StabType"))
        {
            currentPanel = panel.transform.Find("StabPanel");
        }
        currentPanel.gameObject.SetActive(true);

        if (currentButton != null)
        {
            ColorBlock cb1 = currentButton.colors;
            cb1.normalColor = Color.black;
            currentButton.colors = cb1;
        }

        currentButton = btn;
        ColorBlock cb = currentButton.colors;
        cb.normalColor = Color.blue;
        currentButton.colors = cb;
    }
}
