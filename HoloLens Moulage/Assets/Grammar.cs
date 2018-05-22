using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Linq;
using Vuforia;

public class Grammar : MonoBehaviour
{
    GrammarRecognizer grammarRecognizer;
    GameObject xRay;
    GameObject test;
    GameObject result;
    public GameObject menu;
    public GameObject itemCanvas;
    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public GameObject imageTarget3;
    public GameObject imageTarget4;
    public GameObject imageTarget5;
    public GameObject cursor;

    void Start()
    {
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
        string key = meanings[0].values[0];

        int k = 1;
        foreach (SemanticMeaning meaning in meanings)
        {
            print(k);
            foreach (string s in meaning.values)
            {
                print(meaning.key + " " + s);
            }
            k++;
        }

        if (key == "basiccommand")
        {
            string[] items = meanings[1].values;
            string[] actions = meanings[2].values;

            for (int i = 0; i < actions.Length; i++)
            {
                string[] subitems = items[i].Split();
                for (int j = 0; j < subitems.Length; j++)
                {
                    actionResponse(actions[i], subitems[j]);
                }
            }
        }
        else if (key == "targetimagecommand")
        {
            string[] targets = meanings[1].values;
            string[] wounds = meanings[2].values;
            string[] actions = meanings[3].values;

            for (int i = 0; i < actions.Length; i++)
            {
                string[] subitems = targets[i].Split();
                for (int j = 0; j < subitems.Length; j++)
                {
                    actionResponse(actions[i], subitems[j], wounds[i]);
                    print(subitems[j] + " " + wounds[i]);
                }
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
        cursor.SetActive(true);
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
        cursor.SetActive(false);
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

    void actionResponse(string action, string target, string wound)
    {
        if (action == "show" && wound != "null")
        {
            resetWound(target);
            string num = "IT" + target.Substring(11, target.Length - 11);
            GameObject.Find(target).transform.Find(num + wound).gameObject.SetActive(true);
        }
        else if (action == "close")
        {
            resetWound(target);
        }
    }

    private void resetWound(string target)
    {
        string num = "IT" + target.Substring(11, target.Length - 11);
        GameObject.Find(target).transform.Find(num + "Gunshot1").gameObject.SetActive(false);
        GameObject.Find(target).transform.Find(num + "Gunshot2").gameObject.SetActive(false);
        GameObject.Find(target).transform.Find(num + "Slash1").gameObject.SetActive(false);
        GameObject.Find(target).transform.Find(num + "Slash2").gameObject.SetActive(false);
        GameObject.Find(target).transform.Find(num + "Stab1").gameObject.SetActive(false);
        GameObject.Find(target).transform.Find(num + "Stab2").gameObject.SetActive(false);
    }
}