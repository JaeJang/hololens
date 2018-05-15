using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget2Scrpt : MonoBehaviour {
    public GameObject wound;
    void Start()
    {
        GameObject target2 = GameObject.FindGameObjectWithTag("IT2");
        wound.transform.SetParent(target2.transform, false);
        wound.SetActive(false);
    }
}
