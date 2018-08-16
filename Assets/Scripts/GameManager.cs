using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Color worldHue;

    public string questString;
    public int exp;
    string[] words;
    char c;

    public string key;
    public int quantity = -1;


    bool questSatisfiable;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ParseKey(string questString)
    {
        this.questString = questString;
        words = questString.Split(' ');

        if (words[1] == "Find")
        {
            key = words[3];
            quantity = -1;

        }
        else if (words[1] == "Retrieve")
        {
            key = words[3];
            c = words[2][0];
            quantity = c - '0';

        }
        else if (words[1] == "Locate")
        {
            key = words[3];
            c = words[2][0];
            quantity = c - '0';


        }

        

        if (words[words.Length - 5] == "<br>Recieved")
        {
            exp = System.Int32.Parse(words[words.Length - 6]);

        }
        else
        {
            exp = System.Int32.Parse(words[words.Length - 5]);

        }


    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }



}
