using UnityEngine;
using System.Collections;

public class ImgTarget1Scrpt : MonoBehaviour
{

    void Start()
    {
        GameObject target1 = GameObject.FindGameObjectWithTag("IT1");
        transform.SetParent(target1.transform, false);
        transform.gameObject.SetActive(false);
    }
}