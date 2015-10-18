using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LobbyGUIScript : MonoBehaviour
{

    public Rect wordCenter;

    public GUIStyle style = null;
    public GUIStyle centeredStyle = null;
    public GUIStyle scoreStyle;

    public Texture2D starImage;


    void Start()
    {
        style.normal.textColor = Color.gray;
        centeredStyle.normal.textColor = Color.black;
        scoreStyle.normal.textColor = Color.gray;

    }


    void Update()
    {

    }


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(15, 15, 50, 50), starImage, ScaleMode.ScaleToFit, true, 1.0F);     // Tähtikuvake

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


    }


}
