
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepOriginalSize : MonoBehaviour {

    private Vector3 originalSize;

	// Use this for initialization
	void Start () {
        originalSize = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        gameObject.transform.localScale = originalSize;
    }
}
