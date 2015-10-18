using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Points : MonoBehaviour
{

    public static int score = 10000;
    public static int stars = 100;
    public static int jumps = 0;
    public static int deaths = 0;
    public float secondsToShowAchievementGained = 5.0f;

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
    public static Dictionary<int, bool> boostersUsed = new Dictionary<int, bool>();

    public static Dictionary<int, string> hints = new Dictionary<int, string>();
    public static Dictionary<int, string> words = new Dictionary<int, string>();



    void Start()
    {

        achievementStyle.normal.textColor = Color.black;

        if (achievements.Count == 0)
        {

            hints.Add(0, "Elektronisk maskin som används för att behandla data");
            words.Add(0, "Dator");

            hints.Add(1, "Digitalt meddelande");
            words.Add(1, "emejl");

            hints.Add(2, "Kortform av mobiltelefon");
            words.Add(2, "mobil");

            hints.Add(3, "Avdelning hos företag som bemöter kunders frågor");
            words.Add(3, "kundtjänst");

            hints.Add(4, "Ett sätt att avsluta ett e-post");
            words.Add(4, "mvh");

            hints.Add(5, "Tangentbaserad inmatningsenhet för datorer");
            words.Add(5, "tangentbord");

            hints.Add(6, "Utmatningsenhet för dator vilken visar en bild");
            words.Add(6, "bildskärm");

            hints.Add(7, "Ekonomisk organisation");
            words.Add(7, "företag");

            hints.Add(8, "Enhet för pappersutskrift av digitalt dokument");
            words.Add(8, "skrivare");



            achievements.Add(0, "Första ordet");     // TÄHÄN LISÄTÄÄN ACHIEVEMENTIT
            achievementsDone.Add(0, false);          // TÄHÄN LAITETAAN TIETO SIITÄ ONKO SE SUORITTETTU
            achievementsShown.Add(0, false);

            achievements.Add(1, "Alla stjärnor samlas");
            achievementsDone.Add(1, false);
            achievementsShown.Add(1, false);

            achievements.Add(2, "Hoppa 50 gånger");
            achievementsDone.Add(2, false);
            achievementsShown.Add(2, false);

            achievements.Add(3, "Hoppa 100 gånger");
            achievementsDone.Add(3, false);
            achievementsShown.Add(3, false);

            achievements.Add(4, "Hoppa 200 gånger");
            achievementsDone.Add(4, false);
            achievementsShown.Add(4, false);

            achievements.Add(5, "20000 poäng");
            achievementsDone.Add(5, false);
            achievementsShown.Add(5, false);

            achievements.Add(6, "50000 poäng");
            achievementsDone.Add(6, false);
            achievementsShown.Add(6, false);

            achievements.Add(7, "5 ord");      
            achievementsDone.Add(7, false);
            achievementsShown.Add(7, false);

            achievements.Add(8, "10 ord");      
            achievementsDone.Add(8, false);
            achievementsShown.Add(8, false);

            achievements.Add(9, "Alla ord");      
            achievementsDone.Add(9, false);
            achievementsShown.Add(9, false);

            achievements.Add(10, "Dö fem gånger");
            achievementsDone.Add(10, false);
            achievementsShown.Add(10, false);

            //achievements.Add(11, "Random achievement");
            //achievementsDone.Add(11, false);
            //achievementsShown.Add(11, false);

            //achievements.Add(12, "Random achievement");
            //achievementsDone.Add(12, false);
            //achievementsShown.Add(12, false);

            //achievements.Add(13, "Random achievement");
            //achievementsDone.Add(13, false);
            //achievementsShown.Add(13, false);

            //achievements.Add(14, "Random achievement");
            //achievementsDone.Add(14, false);
            //achievementsShown.Add(14, false);

            //achievements.Add(15, "Random achievement");
            //achievementsDone.Add(15, false);
            //achievementsShown.Add(16, false);



            boosters.Add(0, "hastighet +");         // TÄHÄN LISÄTÄÄN BOOSTERIT
            boostersBought.Add(0, false);       // TÄHÄN LAITETAAN TIETO SIITÄ ONKO SE OSTETTU JA KÄYTÖSSÄ
            boostersPrice.Add(0, 5);            // TÄHÄN LAITETAAN BOOSTERIN HINTA
            boostersUsed.Add(0, false);

            boosters.Add(1, "hastighet ++");
            boostersBought.Add(1, false);
            boostersPrice.Add(1, 10);
            boostersUsed.Add(1, false);

            boosters.Add(2, "Hoppar +");
            boostersBought.Add(2, false);
            boostersPrice.Add(2, 5);
            boostersUsed.Add(2, false);

            boosters.Add(3, "Hoppar ++");
            boostersBought.Add(3, false);
            boostersPrice.Add(3, 10);
            boostersUsed.Add(3, false);

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

        if (!boostersUsed[0] && boostersBought[0])
        {
            BallMovementScript.pushForce += 3;
            BallMovementScript.originalPushForce += 3;
            boostersUsed[0] = true;
        }

        if (!boostersUsed[1] && boostersBought[1])
        {
            BallMovementScript.pushForce += 8;
            BallMovementScript.originalPushForce += 8;
            boostersUsed[1] = true;
        }

        if (!boostersUsed[2] && boostersBought[2])
        {
            BallMovementScript.jumpForce += 30;
            boostersUsed[2] = true;
        }

        if (!boostersUsed[3] && boostersBought[3])
        {
            BallMovementScript.jumpForce += 60;
            boostersUsed[3] = true;
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

        if (indexOfNextWord == words.Count + 1)
        {
            achievementsDone[9] = true;
            indexOfNextWord = 0;
        }

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


    void Update()
    {


        if (!achievementsShown[1] && achievementsDone[1])
        {
            achievementsShown[1] = true;
            achievementsDone[1] = true;
            AchievementCompleted(achievements[1]);
        }

        if (!achievementsShown[2] && achievementsDone[2])
        {
            achievementsShown[2] = true;
            achievementsDone[2] = true;
            AchievementCompleted(achievements[2]);
        }

        if (!achievementsShown[3] && achievementsDone[3])
        {
            achievementsShown[3] = true;
            achievementsDone[3] = true;
            AchievementCompleted(achievements[3]);
        }

        if (!achievementsShown[4] && achievementsDone[4])
        {
            achievementsShown[4] = true;
            achievementsDone[4] = true;
            AchievementCompleted(achievements[4]);
        }

        if (!achievementsShown[5] && score >= 20000)
        {
            achievementsShown[5] = true;
            achievementsDone[5] = true;
            AchievementCompleted(achievements[5]);
        }

        if (!achievementsShown[6] && score >= 50000)
        {
            achievementsShown[6] = true;
            achievementsDone[6] = true;
            AchievementCompleted(achievements[6]);
        }

        if (!achievementsShown[7] && indexOfNextWord == 5)
        {
            achievementsShown[7] = true;
            achievementsDone[7] = true;
            AchievementCompleted(achievements[7]);
        }

        if (!achievementsShown[8] && indexOfNextWord == 10)
        {
            achievementsShown[8] = true;
            achievementsDone[8] = true;
            AchievementCompleted(achievements[8]);
        }

        if (!achievementsShown[9] && achievementsDone[9])
        {
            achievementsShown[9] = true;
            achievementsDone[9] = true;
            AchievementCompleted(achievements[9]);
        }

        if (!achievementsShown[10] && deaths == 5)
        {
            achievementsShown[10] = true;
            achievementsDone[10] = true;
            AchievementCompleted(achievements[10]);
        }

    }


}
