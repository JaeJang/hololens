using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammarScriptController : MonoBehaviour {

	public void enableGrammarRecognizer()
    {
        GameObject.Find("HoloLensCamera").GetComponent<Grammar>().enabled = true;
    }

    public void disableGrammarRecognizer()
    {
        GameObject.Find("HoloLensCamera").GetComponent<Grammar>().enabled = false;
    }
}
