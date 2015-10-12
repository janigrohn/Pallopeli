using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    bool paused = false;
    bool showAchievements = false;

    public GUIStyle style = null;
    public GUIStyle buttonStyle = null;
    public GUIStyle emptyStyle = null;
    public GUIStyle doneStyle = null;
    public GUIStyle notDoneStyle = null;

    Vector2 scrollposition = Vector2.zero;
    float hScrollbarValue;

    void Start ()
    {
        doneStyle.normal.textColor = Color.black;
        notDoneStyle.normal.textColor = Color.red;
        buttonStyle.normal.textColor = Color.yellow;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            paused = togglePause();
    }


    void OnGUI()
    {
        if (paused && showAchievements)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 15, Screen.height / 2 - 120, 500, 400));
            GUILayout.BeginVertical();


            GUILayout.Label("Game is paused", style);
            GUILayout.Label("", style);

            if (GUILayout.Button("Resume", buttonStyle))
                paused = togglePause();

            if (GUILayout.Button("Achievements", buttonStyle))
            {
                if (!showAchievements)
                    showAchievements = true;
                else
                    showAchievements = false;
            }

            if (GUILayout.Button("Quit", buttonStyle))
                Application.Quit();


            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        else if (paused)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 120, 500, 400));
            GUILayout.BeginVertical();


            GUILayout.Label("Game is paused!", style);
            GUILayout.Label("", style);

            if (GUILayout.Button("Resume", buttonStyle))
                paused = togglePause();

            if (GUILayout.Button("Achievements", buttonStyle))
            {
                if (!showAchievements)
                    showAchievements = true;
                else
                    showAchievements = false;
            }

            if (GUILayout.Button("Quit", buttonStyle))
                Application.Quit();


            GUILayout.EndVertical();
            GUILayout.EndArea();
        }


        if (showAchievements)
        {
            scrollposition = GUI.BeginScrollView(new Rect(Screen.width - 820, 100, 800, Screen.height - 200), scrollposition, new Rect(0, 0, 780, Points.achievements.Count * 35), false, false);

            GUILayout.BeginArea(new Rect(0, 0, 780, Points.achievements.Count * 35));


            for(int i = 0; i < Points.achievements.Count; i++)
            {
                if (Points.achievementsDone[i] != true)
                {
                    GUILayout.Label(Points.achievements[i], notDoneStyle);
                }
                else
                {
                    GUILayout.Label(Points.achievements[i], doneStyle);
                }
                
                GUILayout.Label(" ", emptyStyle);
            }
            
            
            GUILayout.EndArea();

            GUI.EndScrollView();

        }
    }


    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            showAchievements = false;
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
