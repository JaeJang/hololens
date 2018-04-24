using UnityEngine;
using UnityEngine.UI;

public class ShowTest: MonoBehaviour {

    void Start () {

        TextAsset text = Resources.Load("test") as TextAsset;
        Text dataFrame = GameObject.Find("ItemCanvas/Test").GetComponent<UnityEngine.UI.Text>();
        dataFrame.text = text.text;
    }
	
	void Update () {
		
	}
}
