using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onGazeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if(Physics.Raycast(headPosition,gazeDirection, out hitInfo))
        {
            print("hello");
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
