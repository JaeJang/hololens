using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;

public class Grammar : MonoBehaviour
{
    GrammarRecognizer grammarRecognizer;

    void Start()
    {
        grammarRecognizer = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "test.xml"));
        grammarRecognizer.OnPhraseRecognized += grammarRecognizer_OnPhraseRecognized;
        grammarRecognizer.Start();
    }

    void grammarRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        print(args.text);
        print(args.semanticMeanings);
    }
}