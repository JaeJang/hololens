using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeCollider : MonoBehaviour {

    public GameObject wall;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnEnable()
    {
        wall.SetActive(true);

    }

    void OnDisable()
    {
        wall.SetActive(false);
    }

    public void setCollider()
    {
        
    }

    private void updateCollider(RectTransform rect)
    {
        //RectTransform rect = (RectTransform)t.transform;
        if (rect.gameObject.GetComponent<BoxCollider>() == null)
            rect.gameObject.AddComponent<BoxCollider>();

        Vector3 size = new Vector3(rect.rect.size.x, rect.rect.size.y, 1);
        
        BoxCollider collider = rect.GetComponent<BoxCollider>();
        //Vector3 newCenter = new Vector3(rect.pivot.x, rect.pivot.y, 0);
        collider.center = Vector3.zero;//newCenter;
        collider.size = size;
        Debug.Log(rect.name + ", size: " + size );
        
        //if (rect.gameObject.GetComponent<BoxCollider2D>() == null)
        //    rect.gameObject.AddComponent<BoxCollider2D>();

        //Vector2 size = rect.rect.size;

        //BoxCollider2D collider = rect.GetComponent<BoxCollider2D>();
        //Vector3 newCenter = new Vector3(rect.pivot.x, rect.pivot.y);
        //collider.offset = Vector2.zero;//newCenter;
        //collider.size = size;
        //Debug.Log(rect.name + ", size: " + size + ", center: " + newCenter);
    }
}
