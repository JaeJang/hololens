using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {

    public GameObject wound1;
    public GameObject wound2;
    public GameObject wound3;
    public GameObject wound4;
    GameObject currentImage;
    Button currentButton;


    // Use this for initialization
    void Start () {
        currentImage = wound1;
        currentImage.SetActive(true);
        print("MoveSecne");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickTest(Button btn)
    {
        //string name;
        //name = EventSystem.current.currentSelectedGameObject.name;
        if (btn.name.Equals("Scene1"))
        {

            changeImageAndButton(btn, 1);

            //SceneManager.LoadScene("Scene1");
        }
        else if (btn.name.Equals("Scene2"))
        {
            changeImageAndButton(btn, 2);
            //SceneManager.LoadScene("Scene2");
        }
        else if (btn.name.Equals("Scene3"))
        {
            changeImageAndButton(btn, 3);
            //SceneManager.LoadScene("Scene3");
        }
        else if (btn.name.Equals("Scene4"))
        {
            changeImageAndButton(btn, 4);
            //SceneManager.LoadScene("Scene4");
        }

    }

    private void changeImageAndButton(Button btn, int wound)
    {
        Debug.Log(btn.name);
        currentImage.SetActive(false);
        if(wound == 1)
        {
            currentImage = wound1;
        }
        else if(wound == 2)
        {
            currentImage = wound2;
        }
        else if(wound == 3)
        {
            currentImage = wound3;
        }
        else if(wound == 4)
        {
            currentImage = wound4;
        }
        currentImage.SetActive(true);

        if(currentButton != null)
        {
            ColorBlock cb1 = currentButton.colors;
            cb1.normalColor = Color.white;
            currentButton.colors = cb1;
        }
        currentButton = btn;
        ColorBlock cb = currentButton.colors;
        cb.normalColor = Color.blue;    
        currentButton.colors = cb;

    }
}
