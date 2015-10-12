using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Points : MonoBehaviour {

    public static int score = 10000;
    public static int stars = 0;

    public static string nextHint;
    public static string nextWord;

    public static Dictionary<int, string> achievements = new Dictionary<int, string>();
    public static Dictionary<int, bool> achievementsDone = new Dictionary<int, bool>();

    void Start () {

        nextHint = "Hint goes here              WASD liikkuu, F kerää kirjaimia, ESC pausettaa";
        nextWord = "Word";      // Välilyönnit ei (tällä hetkellä) toimi

        achievements.Add(0, "First word completed");
        achievementsDone.Add(0, false);

        achievements.Add(1, "All stars collected");
        achievementsDone.Add(1, false);

        achievements.Add(2, "A word in less than a minute");
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


    }


    void Update () {
        
	}
}
