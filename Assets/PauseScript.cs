using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public static bool paused = false;
    bool showAchievements = false;
    public static bool showOptions = false;

    public Transform dimPlane;
    public Transform camera;

    public GUIStyle style = null;
    public GUIStyle buttonStyle = null;
    public GUIStyle emptyStyle = null;
    public GUIStyle doneStyle = null;
    public GUIStyle notDoneStyle = null;

    public static float mouseSensitivity = 5.0f;

    Vector2 scrollposition = Vector2.zero;
    float hScrollbarValue;

    void Start ()
    {
        style.normal.textColor = Color.black;
        doneStyle.normal.textColor = Color.green;
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
        if ((paused && showAchievements) || (paused && showOptions))
        {
            GUILayout.BeginArea(new Rect(Screen.width / 15, Screen.height / 2 - 120, 500, 400));
            GUILayout.BeginVertical();


            GUILayout.Label("Spelet är pausat", style);
            GUILayout.Label("", style);

            if (GUILayout.Button("Fortsätt", buttonStyle))
                paused = togglePause();

            if (GUILayout.Button("Achievements(!)", buttonStyle))
            {
                if (!showAchievements)
                {
                    showOptions = false;
                    showAchievements = true;
                } 
                else
                    showAchievements = false;
            }

            if (GUILayout.Button("Options(!)", buttonStyle))
            {
                if (!showOptions)
                {
                    showAchievements = false;
                    showOptions = true;
                }
                else
                {
                    showOptions = false;
                }
            }

            if (GUILayout.Button("Sluta", buttonStyle))
                Application.Quit();


            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        else if (paused)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 120, 500, 400));
            GUILayout.BeginVertical();


            GUILayout.Label("Spelet är pausat!", style);
            GUILayout.Label("", style);

            if (GUILayout.Button("Fortsätt", buttonStyle))
                paused = togglePause();

            if (GUILayout.Button("Achievements(!)", buttonStyle))
            {
                if (!showAchievements)
                {
                    showOptions = false;
                    showAchievements = true;
                }
                else
                    showAchievements = false;
            }

            if (GUILayout.Button("Options(!)", buttonStyle))
            {
                if (!showOptions)
                {
                    showAchievements = false;
                    showOptions = true;
                }
                else
                {
                    showOptions = false;
                }
            }

            if (GUILayout.Button("Sluta", buttonStyle))
                Application.Quit();


            GUILayout.EndVertical();
            GUILayout.EndArea();
        }


        if (showAchievements)
        {
            scrollposition = GUI.BeginScrollView(new Rect(Screen.width - 820, 100, 800, Screen.height - 200), scrollposition, new Rect(0, 0, 780, Points.achievements.Count * 35), false, false);

            GUILayout.BeginArea(new Rect(100, 0, 780, Points.achievements.Count * 35));


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


        if (showOptions)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 600, 200, 400, Screen.height - 400));

            GUILayout.Label("Musens sensitivitet", buttonStyle);
            mouseSensitivity = GUILayout.HorizontalSlider(mouseSensitivity, 1.0f, 10.0f);
            GUILayout.Label(mouseSensitivity.ToString("F2"), buttonStyle);

            GUILayout.EndArea();
        }

    }


    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            showAchievements = false;
            showOptions = false;
            StarShopScript.showStarShop = false;
            Time.timeScale = 1f;
            //Destroy(GameObject.Find("DimPlane(Clone)"));
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            //Instantiate(dimPlane, camera.position + camera.forward * 1, Quaternion.identity);
            return (true);
        }
    }
}
