using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using Vuforia;

public class Keyword : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    GameObject itemCanvas;
    GameObject xRay;
    GameObject test;
    GameObject result;
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
        test = itemCanvas.transform.Find("Test").gameObject;
        result = itemCanvas.transform.Find("Result").gameObject;

        xRay.SetActive(false);
        test.SetActive(false);
        result.SetActive(false);
        keywords.Add("Steve, menu on", () => { displayMenu(); });
        keywords.Add("Steve, show me the menu", () => { displayMenu(); });
        keywords.Add("Steve, menu off", () => { closeMenu(); });
        keywords.Add("Steve, x-ray on", () => { displayXRay(); });
        keywords.Add("Steve, show me the x-ray", () => { displayXRay(); });
        keywords.Add("Steve, x-ray off", () => { closeXRay(); });
        keywords.Add("Steve, data on", () => { displayData(); });
        keywords.Add("Steve, show me the data", () => { displayData(); });
        keywords.Add("Steve, data off", () => { closeData(); });
        keywords.Add("Steve, x-ray and data off", () => { closeXray_data(); });
        keywords.Add("Steve, data and x-ray off", () => { closeXray_data(); });
        keywords.Add("Steve, remove the image", () => { displayMenu(); });
        keywords.Add("Steve, remove all", () => { displayMenu(); });
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
        closeXray_data();
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
        //Vector3 newPos = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z + 3);

        //itemCanvas.transform.position = newPos;
        //xRay.transform.position = newPos;
        itemCanvas.SetActive(true);
        xRay.SetActive(true);
    }

    void displayData()
    {
        menu.SetActive(false);
        itemCanvas.SetActive(true);
        test.SetActive(true);
        result.SetActive(true);
    }

    void closeData()
    {
        test.SetActive(false);
        result.SetActive(false);
    }

    void closeXRay()
    {
        //GameObject xray = itemCanvas.transform.Find("X-Ray").gameObject;
        //xray.SetActive(false);
        xRay.SetActive(false);
    }

    void closeXray_data()
    {
        closeData();
        closeXRay();
    }

    
}