using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour, IFocusable {

    public GameObject panel;
    public void OnFocusEnter()
    {
        print("hello world");
        panel.transform.Find("Yuck1").gameObject.SetActive(true);
        //throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        print("bye world");
        panel.transform.Find("Yuck1").gameObject.SetActive(false);
        //throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
