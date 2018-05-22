using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {

    public AudioClip sound;
    public GameObject ImageTarget;
    public Transform menu;
    private Transform currentImage;
    private Button currentButton;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickTest(Button btn)
    {
        //string name;
        //name = EventSystem.current.currentSelectedGameObject.name;
        if(currentImage != null)
        {
            currentImage.gameObject.SetActive(false);
        }
        string buttonName = btn.name;
        currentImage = ImageTarget.transform.Find(buttonName);
        currentImage.gameObject.SetActive(true);

        //if (currentButton != null)
        //{
        //    ColorBlock cb1 = currentButton.colors;
        //    cb1.normalColor = Color.white;
        //    currentButton.colors = cb1;
        //}

        //currentButton = btn;
        //ColorBlock cb = currentButton.colors;
        //cb.normalColor = Color.blue;
        //currentButton.colors = cb;

        menu.gameObject.SetActive(false);
        
    }

    
}
