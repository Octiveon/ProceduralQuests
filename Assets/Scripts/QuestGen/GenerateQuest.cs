using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityTracery;

public class GenerateQuest : MonoBehaviour {
    public TextAsset GrammarFile;
    public TextMeshProUGUI TextOutput;
    
    private TraceryGrammar grammar;
    private void Start()
    {
        grammar = new TraceryGrammar(GrammarFile.text);

    }

    public void GenerateOutput()
    {
        string output = grammar.Parse("#origin#");
        output.Replace("<br>", "\\n");



        TextOutput.text = output;
        GameManager.instance.ParseKey(TextOutput.text);

    }

}
