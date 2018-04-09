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
    GameObject xRay;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject menu;
    public GameObject imageTarget;
    DefaultTrackableEventHandler defaultTrackable;

    void Start()
    {
        
        if ((itemCanvas = GameObject.Find("ItemCanvas")) == null)
        {
            print("Item Canvas not found.");
        }
        xRay = itemCanvas.transform.Find("X-Ray").gameObject;

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
        defaultTrackable = imageTarget.GetComponent<DefaultTrackableEventHandler>();


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
        
        defaultTrackable.OnTrackableStateChanged(
            TrackableBehaviour.Status.TRACKED,
            TrackableBehaviour.Status.NOT_FOUND);
    }

    void closeMenu()
    {
        print("menu off");

        defaultTrackable.OnTrackableStateChanged(
            TrackableBehaviour.Status.NOT_FOUND,
            TrackableBehaviour.Status.EXTENDED_TRACKED);

    }

    void displayXRay()
    {
        //GameObject xray = itemCanvas.transform.Find("X-Ray").gameObject;
        //xray.SetActive(true);
        //text.gameObject.SetActive(true);
        print("x-ray on");
         menu.SetActive(false);

        //Vector3 cameraPos = Camera.main.transform.position;
        //Vector3 newPosCanvas = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z + 3);
        //Vector3 newPosXRay = new Vector3(cameraPos.x - 70, cameraPos.y -(float)2.2, cameraPos.z + 3);
        //Vector3 newRotation = Camera.main.transform.forward;
        //itemCanvas.transform.position = newPosCanvas;
        //itemCanvas.transform.rotation = Quaternion.LookRotation(newRotation);
        //xRay.transform.position = newPosXRay;
        //xRay.transform.rotation = Quaternion.LookRotation(newRotation);
        itemCanvas.SetActive(true);
        xRay.SetActive(true);
    }

    void closeXRay()
    {
        //GameObject xray = itemCanvas.transform.Find("X-Ray").gameObject;
        //xray.SetActive(false);
        xRay.SetActive(false);
        itemCanvas.SetActive(false);
        print("x-ray off");
    }

    
}