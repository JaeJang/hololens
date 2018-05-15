using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget4Scrpt : MonoBehaviour {
    public GameObject wound;
    void Start()
    {
        GameObject target4 = GameObject.FindGameObjectWithTag("IT4");
        wound.transform.SetParent(target4.transform, false);
        wound.SetActive(false);
    }
}
