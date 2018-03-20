using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class whereYouAre : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string objname = gameObject.name;
        Scene scene = SceneManager.GetActiveScene();
        if (objname.Equals(scene.name))
        {
            Button button = GameObject.Find(objname).GetComponent<Button>();
            ColorBlock cb = button.colors;
            cb.normalColor = Color.blue;
            button.colors = cb;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
