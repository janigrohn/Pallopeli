using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GUIScript : MonoBehaviour {

    string hint;
    string currentWord;
    static string currentWordLettersInString;

    static List<string> currentWordLetters = new List<string>();

    public Rect wordCenter;

    public GUIStyle style = null;
    public GUIStyle centeredStyle = null;
    public GUIStyle hintStyle;

    public float secondsToWaitAfterCompleting = 3.0f;
    int wordWidth;
    int hintWidth;

    bool initialized = false;
    bool allLettersCollected = false;

	
	void Start () {

        StartCoroutine(Initialize(1.5f));

        wordCenter = new Rect(Screen.width / 2 - wordWidth / 2, 15, wordWidth, 25);

}
	
	
	void Update () {


        if (initialized && !currentWordLettersInString.Contains("_"))
        {
            allLettersCollected = true;
        }


        if (allLettersCollected)
        {
            initialized = false;
            StartCoroutine(AllLettersCollected());
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    for (int j = 0; j < LetterSpawner.currentWordLettersLeft.Count; j++)
        //    {
        //        Debug.Log(LetterSpawner.currentWordLettersLeft[j]);
        //    }
        //}

	}

    public static void GotNewLetter(string letter)
    {
        int index = LetterSpawner.currentWordLettersLeft.IndexOf(letter);
        currentWordLetters[index] = letter;

        var aStringBuilder = new StringBuilder(currentWordLettersInString);

        if (index == 0)
        {
            aStringBuilder.Remove(1, 1);
            aStringBuilder.Insert(1, letter);
        }
        else
        {
            aStringBuilder.Remove(index * 2 + 1, 1);
            aStringBuilder.Insert(index * 2 + 1, letter);
        }
        
        currentWordLettersInString = aStringBuilder.ToString();

        LetterSpawner.currentWordLettersLeft[index] = "*";

        //for (int i = 0; i < LetterSpawner.currentWordLettersLeft.Count; i++)
        //    Debug.Log(LetterSpawner.currentWordLettersLeft[i]);
    }


    void OnGUI()
    {
        GUI.color = Color.black;

        GUI.Label(wordCenter, currentWordLettersInString, centeredStyle);

        GUI.Label(new Rect(25, Screen.height - 35, hintWidth, 25), hint, hintStyle);

        if (allLettersCollected)
        {
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 3, 500, 100), "Word completed!", style);
        }
    }


    IEnumerator Initialize(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);

        currentWord = LetterSpawner.currentWord;
        hint = LetterSpawner.hint;

        for (int i = 0; i < currentWord.Length; i++)
        {
            currentWordLetters.Add("_");
            currentWordLettersInString = currentWordLettersInString + " " + "_";
        }

        wordWidth = currentWord.Length;
        hintWidth = hint.Length;
        initialized = true;
    }


    IEnumerator AllLettersCollected()
    {
        yield return new WaitForSeconds(secondsToWaitAfterCompleting);
        // TODO: Pisteidenlaskua?
        Application.LoadLevel("Lobby");
    }

}
