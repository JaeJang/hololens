using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getInFrontOfYou : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        Transform camera = Camera.main.transform;
        gameObject.transform.position = camera.position +
                                        camera.forward * 3;

        gameObject.transform.rotation = Quaternion.LookRotation(camera.forward);
    }
}
