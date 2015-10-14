using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Points : MonoBehaviour {

    public static int score = 10000;
    public static int stars = 10;

    public static string nextHint;
    public static string nextWord;

    public static Dictionary<int, string> achievements = new Dictionary<int, string>();
    public static Dictionary<int, bool> achievementsDone = new Dictionary<int, bool>();

    public static Dictionary<int, string> boosters = new Dictionary<int, string>();
    public static Dictionary<int, bool> boostersBought = new Dictionary<int, bool>();
    public static Dictionary<int, int> boostersPrice = new Dictionary<int, int>();

    void Start () {

        nextHint = "Hint goes here              WASD liikkuu, F kerää kirjaimia, ESC pausettaa";
        nextWord = "Word";      // Välilyönnit ei (tällä hetkellä) toimi


        if (achievements.Count == 0)
        {

            achievements.Add(0, "First word completed(!)");
            achievementsDone.Add(0, false);

            achievements.Add(1, "All stars collected(!)");
            achievementsDone.Add(1, false);

            achievements.Add(2, "A word in less than a minute(!)");
            achievementsDone.Add(2, true);

            achievements.Add(3, "Random achievement");
            achievementsDone.Add(3, true);

            achievements.Add(4, "Random achievement");
            achievementsDone.Add(4, true);

            achievements.Add(5, "Random achievement");
            achievementsDone.Add(5, false);

            achievements.Add(6, "Random achievement");
            achievementsDone.Add(6, true);

            achievements.Add(7, "Random achievement");
            achievementsDone.Add(7, true);

            achievements.Add(8, "Random achievement");
            achievementsDone.Add(8, false);

            achievements.Add(9, "Random achievement");
            achievementsDone.Add(9, true);

            achievements.Add(10, "Random achievement");
            achievementsDone.Add(10, true);

            achievements.Add(11, "Random achievement");
            achievementsDone.Add(11, false);

            achievements.Add(12, "Random achievement");
            achievementsDone.Add(12, true);

            achievements.Add(13, "Random achievement");
            achievementsDone.Add(13, true);

            achievements.Add(14, "Random achievement");
            achievementsDone.Add(14, true);

            achievements.Add(15, "Random achievement");
            achievementsDone.Add(15, true);

            achievements.Add(16, "Random achievement");
            achievementsDone.Add(16, true);

            achievements.Add(17, "Random achievement");
            achievementsDone.Add(17, true);

            achievements.Add(18, "Random achievement");
            achievementsDone.Add(18, true);

            achievements.Add(19, "Random achievement");
            achievementsDone.Add(19, true);

            achievements.Add(20, "Random achievement");
            achievementsDone.Add(20, true);

            achievements.Add(21, "Random achievement");
            achievementsDone.Add(21, true);


            boosters.Add(0, "Speed +");
            boostersBought.Add(0, false);
            boostersPrice.Add(0, 5);

            boosters.Add(1, "Speed +");
            boostersBought.Add(1, false);
            boostersPrice.Add(1, 5);

            boosters.Add(2, "Speed +");
            boostersBought.Add(2, false);
            boostersPrice.Add(2, 5);

            boosters.Add(3, "Speed ++");
            boostersBought.Add(3, true);
            boostersPrice.Add(3, 10);

            boosters.Add(4, "Jumpforce +");
            boostersBought.Add(4, false);
            boostersPrice.Add(4, 5);

            boosters.Add(5, "Jumpforce +");
            boostersBought.Add(5, false);
            boostersPrice.Add(5, 5);

            boosters.Add(6, "Jumpforce +");
            boostersBought.Add(6, false);
            boostersPrice.Add(6, 5);

            boosters.Add(7, "Jumpforce ++");
            boostersBought.Add(7, true);
            boostersPrice.Add(7, 10);

            boosters.Add(8, "Jotain +");
            boostersBought.Add(8, false);
            boostersPrice.Add(8, 5);

            boosters.Add(9, "Jotain +");
            boostersBought.Add(9, false);
            boostersPrice.Add(9, 5);

            boosters.Add(10, "Jotain +");
            boostersBought.Add(10, true);
            boostersPrice.Add(10, 5);

            boosters.Add(11, "Jotain +");
            boostersBought.Add(11, false);
            boostersPrice.Add(11, 5);

            boosters.Add(12, "Jotain +");
            boostersBought.Add(12, false);
            boostersPrice.Add(12, 5);

            boosters.Add(13, "Jotain +");
            boostersBought.Add(13, false);
            boostersPrice.Add(13, 5);

            boosters.Add(14, "Jotain +");
            boostersBought.Add(14, false);
            boostersPrice.Add(14, 5);

        }

        
    }


    void Update () {
        
	}
}
