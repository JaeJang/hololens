using UnityEngine;
using System.Collections;

public class ImgTarget1Scrpt : MonoBehaviour
{
    public GameObject wound;
    void Start()
    {
        GameObject target1 = GameObject.FindGameObjectWithTag("IT1");
        wound.transform.SetParent(target1.transform, false);
        wound.SetActive(false);
    }
}