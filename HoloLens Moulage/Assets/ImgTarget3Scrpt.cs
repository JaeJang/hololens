using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget3Scrpt : MonoBehaviour {

    void Start()
    {
        GameObject target1 = GameObject.FindGameObjectWithTag("IT3");
        transform.SetParent(target1.transform, false);
        transform.gameObject.SetActive(false);
    }
}
