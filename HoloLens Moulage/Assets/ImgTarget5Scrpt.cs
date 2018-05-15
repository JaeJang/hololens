using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget5Scrpt : MonoBehaviour {
    public GameObject wound;
    void Start()
    {
        GameObject target5 = GameObject.FindGameObjectWithTag("IT5");
        wound.transform.SetParent(target5.transform, false);
        wound.SetActive(false);
    }
}
