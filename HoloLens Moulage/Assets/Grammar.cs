using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Linq;
using Vuforia;

public class Grammar : MonoBehaviour
{
    GrammarRecognizer grammarRecognizer;
    GameObject itemCanvas;
    GameObject xRay;
    GameObject test;
    GameObject result;
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
        defaultTrackable = imageTarget.GetComponent<DefaultTrackableEventHandler>();

        xRay.SetActive(false);
        test.SetActive(false);
        result.SetActive(false);

        grammarRecognizer = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "grammar.xml"), ConfidenceLevel.Medium);
        grammarRecognizer.OnPhraseRecognized += grammarRecognizer_OnPhraseRecognized;
        grammarRecognizer.Start();
    }

    void grammarRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        print(args.text);
        SemanticMeaning[] meanings = args.semanticMeanings;

        string[] items = meanings[0].values;
        string[] actions = meanings[1].values;

        for(int i=0; i<actions.Length; i++)
        {
            string[] subitems = items[i].Split();
            for(int j=0; j<subitems.Length; j++)
            {
                actionResponse(actions[i], subitems[j]);
            }
        }
    }

    void displayXRay()
    {
        menu.SetActive(false);
        itemCanvas.SetActive(true);
        xRay.SetActive(true);
    }
    void displayMenu()
    {
        closeXray_Data();
        defaultTrackable.OnTrackableStateChanged(
            TrackableBehaviour.Status.TRACKED,
            TrackableBehaviour.Status.NOT_FOUND);
    }

    void closeMenu()
    {
        defaultTrackable.OnTrackableStateChanged(
            TrackableBehaviour.Status.NOT_FOUND,
            TrackableBehaviour.Status.EXTENDED_TRACKED);

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
        xRay.SetActive(false);
    }

    void closeXray_Data()
    {
        closeData();
        closeXRay();
    }

    void actionResponse(string action, string item)
    {
        if (action == "show")
        {
            if (item == "x-ray")
            {
                displayXRay();
            }
            else if (item == "menu")
            {
                displayMenu();
            }
            else if (item == "data")
            {
                displayData();
            }
        }
        else if (action == "close")
        {
            if (item == "x-ray")
            {
                closeXRay();
            }
            else if (item == "menu")
            {
                closeMenu();
            }
            else if (item == "data")
            {
                closeData();
            }
            else if (item == "all")
            {
                closeXray_Data();
            }
        }
    }
}