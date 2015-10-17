using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Points : MonoBehaviour {

    public static int score = 10000;
    public static int stars = 0;
    public float secondsToShowAchievementGained = 4.0f;

    string achievementText;
    bool showAchievementText = false;

    public GUIStyle achievementStyle = null;

    public static string nextHint;
    public static string nextWord;
    public static int indexOfNextWord = 0;

    public static Dictionary<int, string> achievements = new Dictionary<int, string>();
    public static Dictionary<int, bool> achievementsDone = new Dictionary<int, bool>();
    public static Dictionary<int, bool> achievementsShown = new Dictionary<int, bool>();

    public static Dictionary<int, string> boosters = new Dictionary<int, string>();
    public static Dictionary<int, bool> boostersBought = new Dictionary<int, bool>();
    public static Dictionary<int, int> boostersPrice = new Dictionary<int, int>();

    public static Dictionary<int, string> hints = new Dictionary<int, string>();
    public static Dictionary<int, string> words = new Dictionary<int, string>();



    void Start () {

        achievementStyle.normal.textColor = Color.black;

        if (achievements.Count == 0)
        {

            hints.Add(0, "First hint goes here: word         WASD rörelse, F använd, ESC paus");
            words.Add(0, "w");

            hints.Add(1, "Second hint goes here: sana");
            words.Add(1, "s");

            hints.Add(2, "Third hint goes here: ord");      // TÄHÄN LISÄTÄÄN VIHJEET
            words.Add(2, "Ord");                            // TÄHÄN LISÄTÄÄN SANAT



            achievements.Add(0, "Första ordet");     // TÄHÄN LISÄTÄÄN ACHIEVEMENTIT
            achievementsDone.Add(0, false);          // TÄHÄN LAITETAAN TIETO SIITÄ ONKO SE SUORITTETTU
            achievementsShown.Add(0, false);

            achievements.Add(1, "Alla stjärnor samlas");
            achievementsDone.Add(1, false);
            achievementsShown.Add(1, false);

            achievements.Add(2, "Random achievement");
            achievementsDone.Add(2, false);
            achievementsShown.Add(2, false);

            achievements.Add(3, "Random achievement");
            achievementsDone.Add(3, false);
            achievementsShown.Add(3, false);

            achievements.Add(4, "Random achievement");
            achievementsDone.Add(4, false);
            achievementsShown.Add(4, false);

            achievements.Add(5, "Random achievement");
            achievementsDone.Add(5, false);
            achievementsShown.Add(5, false);

            achievements.Add(6, "Random achievement");
            achievementsDone.Add(6, false);
            achievementsShown.Add(6, false);

            achievements.Add(7, "Random achievement");
            achievementsDone.Add(7, false);
            achievementsShown.Add(7, false);

            achievements.Add(8, "Random achievement");
            achievementsDone.Add(8, false);
            achievementsShown.Add(8, false);

            achievements.Add(9, "Random achievement");
            achievementsDone.Add(9, false);
            achievementsShown.Add(9, false);

            achievements.Add(10, "Random achievement");
            achievementsDone.Add(10, false);
            achievementsShown.Add(10, false);

            achievements.Add(11, "Random achievement");
            achievementsDone.Add(11, false);
            achievementsShown.Add(11, false);

            achievements.Add(12, "Random achievement");
            achievementsDone.Add(12, false);
            achievementsShown.Add(12, false);

            achievements.Add(13, "Random achievement");
            achievementsDone.Add(13, false);
            achievementsShown.Add(13, false);

            achievements.Add(14, "Random achievement");
            achievementsDone.Add(14, false);
            achievementsShown.Add(14, false);

            achievements.Add(15, "Random achievement");
            achievementsDone.Add(15, false);
            achievementsShown.Add(16, false);



            boosters.Add(0, "hastighet +");         // TÄHÄN LISÄTÄÄN BOOSTERIT
            boostersBought.Add(0, false);       // TÄHÄN LAITETAAN TIETO SIITÄ ONKO SE OSTETTU JA KÄYTÖSSÄ
            boostersPrice.Add(0, 5);            // TÄHÄN LAITETAAN BOOSTERIN HINTA

            boosters.Add(1, "hastighet ++");
            boostersBought.Add(1, false);
            boostersPrice.Add(1, 5);

            boosters.Add(2, "Hoppar +");
            boostersBought.Add(2, false);
            boostersPrice.Add(2, 5);

            boosters.Add(3, "Hoppar ++");
            boostersBought.Add(3, false);
            boostersPrice.Add(3, 10);

            //boosters.Add(4, "Jumpforce +");
            //boostersBought.Add(4, false);
            //boostersPrice.Add(4, 5);

            //boosters.Add(5, "Jumpforce +");
            //boostersBought.Add(5, false);
            //boostersPrice.Add(5, 5);

            //boosters.Add(6, "Jumpforce +");
            //boostersBought.Add(6, false);
            //boostersPrice.Add(6, 5);

            //boosters.Add(7, "Jumpforce ++");
            //boostersBought.Add(7, true);
            //boostersPrice.Add(7, 10);



        }

        nextHint = hints[indexOfNextWord];
        nextWord = words[indexOfNextWord];

        if (boostersBought[0])
        {
            BallMovementScript.pushForce += 3;
            BallMovementScript.originalPushForce += 3;
        }

        if (boostersBought[1])
        {
            BallMovementScript.pushForce += 8;
            BallMovementScript.originalPushForce += 8;
        }

        if (boostersBought[2])
        {
            BallMovementScript.jumpForce += 30;
        }

        if (boostersBought[3])
        {
            BallMovementScript.jumpForce += 60;
        }


        if (!achievementsShown[0] && indexOfNextWord == 1)
        {
            achievementsShown[0] = true;
            achievementsDone[0] = true;
            AchievementCompleted(achievements[0]);
        }


    }

    
    public static void WordCompleted()
    {
        indexOfNextWord++;

    }


    public void AchievementCompleted(string text)
    {
        achievementText = "Prestation färdig:\n " + text;
        showAchievementText = true;
        StartCoroutine(ShowAchievement());
    }


    public void OnGUI()
    {
        if (showAchievementText)
        {
            GUI.Label(new Rect(25, Screen.height / 2 - 50, 600, 100), achievementText, achievementStyle);

        }
    }


    IEnumerator ShowAchievement()
    {
        yield return new WaitForSeconds(secondsToShowAchievementGained);
        showAchievementText = false;
    }


    void Update() {

        if (!achievementsShown[1] && achievementsDone[1])
        {
            achievementsShown[1] = true;
            achievementsDone[1] = true;
            AchievementCompleted(achievements[1]);
        }

	}


}
