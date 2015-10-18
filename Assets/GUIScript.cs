using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GUIScript : MonoBehaviour
{

    string hint;
    string currentWord;
    static string currentWordLettersInString;

    static List<string> currentWordLetters = new List<string>();

    public Rect wordCenter;

    public GUIStyle style = null;
    public GUIStyle centeredStyle = null;
    public GUIStyle hintStyle;
    public GUIStyle scoreStyle;
    public GUIStyle plusScoreStyle;
    public GUIStyle minusScoreStyle;

    public Texture2D starImage;

    public float showScoreChangeTime = 2.0f;
    public float secondsToWaitAfterCompleting = 3.0f;

    int wordWidth;
    int hintWidth;

    static int scoreChangeValue;

    bool initialized = false;
    bool allLettersCollected = false;
    static bool showScoreChange = false;
    static bool showScoreChange2 = false;
    static bool coRoutineRunning = false;
    static bool coRoutine2Running = false;



    void Start()
    {

        currentWordLettersInString = "";
        StartCoroutine(Initialize(1.5f));

        wordCenter = new Rect(Screen.width / 2 - wordWidth / 2, 15, wordWidth, 25);

        plusScoreStyle.normal.textColor = Color.green;
        minusScoreStyle.normal.textColor = Color.red;
        style.normal.textColor = Color.black;
        centeredStyle.normal.textColor = Color.black;
        hintStyle.normal.textColor = Color.black;
        scoreStyle.normal.textColor = Color.black;

    }


    void Update()
    {


        if (initialized)
            if (!currentWordLettersInString.Contains("_"))
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
        GUI.DrawTexture(new Rect(15, 15, 50, 50), starImage, ScaleMode.ScaleToFit, true, 1.0F);     // Tähtikuvake

        GUI.Label(wordCenter, currentWordLettersInString, centeredStyle);       // Sana

        GUI.Label(new Rect(25, Screen.height - 35, hintWidth, 25), hint, hintStyle);        // Vihje

        GUI.Label(new Rect(70, 20, 100, 25), Points.stars.ToString(), style);       // Stars

        if (Points.score.ToString().Length == 1)
        {
            GUI.Label(new Rect(Screen.width - 2 * 30, 20, 300, 25), Points.score.ToString(), scoreStyle);       // Score
        }
        else if (Points.score.ToString().Length >= 5)
        {
            GUI.Label(new Rect(Screen.width - Points.score.ToString().Length * 35, 20, 300, 25), Points.score.ToString(), scoreStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width - Points.score.ToString().Length * 40, 20, 300, 25), Points.score.ToString(), scoreStyle);
        }

        if (allLettersCollected)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 3, 500, 100), "Ordet färdig!", style);       // Word completed!
        }

        if (showScoreChange)
        {
            if (scoreChangeValue > 0)
            {
                GUI.Label(new Rect(Screen.width - 180, 55, 300, 25), "+" + scoreChangeValue, plusScoreStyle);
            }
            if (scoreChangeValue < 0)
            {
                GUI.Label(new Rect(Screen.width - 180, 60, 300, 25), scoreChangeValue.ToString(), minusScoreStyle);
            }

            if (!coRoutineRunning)
                StartCoroutine(ShowScoreChange());
        }

        if (showScoreChange2)
        {
            if (scoreChangeValue > 0)
            {
                GUI.Label(new Rect(Screen.width - 180, 55, 300, 25), "+" + scoreChangeValue, plusScoreStyle);
            }
            if (scoreChangeValue < 0)
            {
                GUI.Label(new Rect(Screen.width - 180, 60, 300, 25), scoreChangeValue.ToString(), minusScoreStyle);
            }

            if (!coRoutine2Running)
                StartCoroutine(ShowScoreChange2());
        }

    }

    public static void ShowPointsChange(int value)
    {
        scoreChangeValue = value;

        if (!showScoreChange)
            showScoreChange = true;
        else
            showScoreChange2 = true;

    }

    IEnumerator ShowScoreChange()
    {
        coRoutineRunning = true;
        yield return new WaitForSeconds(showScoreChangeTime);
        showScoreChange = false;
        coRoutineRunning = false;
    }

    IEnumerator ShowScoreChange2()
    {
        coRoutine2Running = true;
        yield return new WaitForSeconds(showScoreChangeTime);
        showScoreChange2 = false;
        coRoutine2Running = false;
    }


    IEnumerator Initialize(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);

        currentWord = LetterSpawner.currentWord;
        hint = LetterSpawner.hint;
        currentWordLetters.Clear();


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
        Points.WordCompleted();
        Application.LoadLevel("Lobby");
    }

}
