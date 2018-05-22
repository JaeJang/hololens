using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget3Scrpt : MonoBehaviour {
    public GameObject wound;
    void Start()
    {
        GameObject target3 = GameObject.FindGameObjectWithTag("IT3");
        wound.transform.SetParent(target3.transform, false);
        wound.SetActive(false);
    }
}
