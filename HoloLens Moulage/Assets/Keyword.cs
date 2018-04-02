using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using Vuforia;

public class Keyword : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    GameObject itemCanvas;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public Transform text;
    public GameObject imageTarget;
    DefaultTrackableEventHandler defaultTrackable;

    void Start()
    {
        if ((itemCanvas = GameObject.Find("ItemCanvas")) == null)
        {
            print("Item Canvas not found.");
        }
        itemCanvas.SetActive(false);
        keywords.Add("Steve, menu on", () => { displayMenu(); });
        keywords.Add("Steve, menu off", () => { closeMenu(); });
        keywords.Add("Steve, x-ray on", () => { displayXRay(); });
        keywords.Add("Steve, x-ray off", () => { closeXRay(); });
        keywords.Add("Steve, remove the image", () => { displayMenu(); });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += keyword_OnPhraseRecognized;
        keywordRecognizer.Start();

        //mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        

    }

    void keyword_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action action;
        if (keywords.TryGetValue(args.text, out action))
        {
            action.Invoke();
        }
    }

    void displayMenu()
    {
        print("menu on");
        defaultTrackable = imageTarget.GetComponent<DefaultTrackableEventHandler>();
        defaultTrackable.OnTrackableStateChanged(
            TrackableBehaviour.Status.TRACKED,
            TrackableBehaviour.Status.NOT_FOUND);
    }

    void closeMenu()
    {
        print("menu off");
    }

    void displayXRay()
    {
        //GameObject xray = itemCanvas.transform.Find("X-Ray").gameObject;
        //xray.SetActive(true);
        //text.gameObject.SetActive(true);
        itemCanvas.SetActive(true);
        print("x-ray on");
    }

    void closeXRay()
    {
        //GameObject xray = itemCanvas.transform.Find("X-Ray").gameObject;
        //xray.SetActive(false);
        itemCanvas.SetActive(false);
        print("x-ray off");
    }
}