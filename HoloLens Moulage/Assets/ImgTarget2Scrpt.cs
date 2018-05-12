using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTarget2Scrpt : MonoBehaviour {

    void Start()
    {
        GameObject target1 = GameObject.FindGameObjectWithTag("IT2");
        transform.SetParent(target1.transform, false);
        transform.gameObject.SetActive(false);
    }
}
