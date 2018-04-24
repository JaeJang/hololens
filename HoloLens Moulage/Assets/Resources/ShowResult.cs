using UnityEngine.UI;
using UnityEngine;

public class ShowResult : MonoBehaviour {

    void Start()
    {
        TextAsset text = Resources.Load("result") as TextAsset;
        Text dataFrame = GameObject.Find("ItemCanvas/Result").GetComponent<UnityEngine.UI.Text>();
        dataFrame.text = text.text;
    }

    void Update()
    {

    }
}
