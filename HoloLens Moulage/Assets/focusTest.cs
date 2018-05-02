using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusTest : MonoBehaviour, IFocusable {
    public void OnFocusEnter()
    {
        //throw new System.NotImplementedException();
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnFocusExit()
    {
        //throw new System.NotImplementedException();
        transform.localScale = new Vector3(0.3085096f, 0.3085096f, 0.3085096f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
