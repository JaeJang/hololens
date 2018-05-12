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
    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public GameObject imageTarget3;
    public GameObject imageTarget4;
    public GameObject imageTarget5;

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

        for (int i = 0; i < actions.Length; i++)
        {
            string[] subitems = items[i].Split();
            for (int j = 0; j < subitems.Length; j++)
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
        menu.SetActive(true);
        menu.transform.Find("MainMenu").gameObject.SetActive(true);
    }

    void closeMenu()
    {
        menu.transform.Find("MainMenu").gameObject.SetActive(false);
        menu.transform.Find("ImageOption").gameObject.SetActive(false);
        menu.transform.Find("WoundType").gameObject.SetActive(false);
        menu.transform.Find("GunshotOption").gameObject.SetActive(false);
        menu.transform.Find("SlashOption").gameObject.SetActive(false);
        menu.transform.Find("StabOption").gameObject.SetActive(false);
        menu.transform.Find("ConfirmMenu").gameObject.SetActive(false);
        menu.SetActive(false);
    }

    void displayData()
    {
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
                closeXRay();
                closeData();
                closeMenu();
            }
        }
    }
}