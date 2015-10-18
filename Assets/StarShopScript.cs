using UnityEngine;
using System.Collections;

public class StarShopScript : MonoBehaviour
{

    GameObject ball;

    public float distanceToBall = 3.0f;

    public static bool showStarShop = false;

    //Vector2 scrollposition = Vector2.zero;
    public GUIStyle style = null;
    public GUIStyle emptyStyle = null;
    public GUIStyle doneStyle = null;
    public GUIStyle notDoneStyle = null;
    public GUIStyle priceStyle = null;

    void Start()
    {

        ball = GameObject.FindGameObjectWithTag("Player");

        doneStyle.normal.textColor = Color.green;
        notDoneStyle.normal.textColor = Color.red;
        priceStyle.normal.textColor = Color.gray;
    }


    void Update()
    {

        if (Vector3.Distance(ball.transform.position, transform.position) < distanceToBall)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (!showStarShop)
                {
                    showStarShop = true;
                }
                else
                {
                    showStarShop = false;
                }

            }
        }
        else
        {
            if (showStarShop)
            {
                showStarShop = false;
            }
        }


    }


    void OnGUI()
    {
        if (showStarShop)
        {
            //if (Points.boosters.Count > 8)
            //    scrollposition = GUI.BeginScrollView(new Rect(Screen.width - 820, 100, 800, Screen.height / 2 + 200), scrollposition, new Rect(0, 0, 780, Points.boosters.Count * 55), false, true);

            //else
            GUILayout.BeginArea(new Rect(Screen.width - 820, 100, 800, Screen.height / 2 + 200));

            GUILayout.BeginArea(new Rect(100, 0, 780, Points.boosters.Count * 55));


            for (int i = 0; i < Points.boosters.Count; i++)
            {
                string text = "Pris: " + Points.boostersPrice[i] + " stjärnor";

                if (Points.boostersBought[i] != true)
                {

                    if (GUILayout.Button(Points.boosters[i], notDoneStyle))
                    {
                        if (Points.stars >= Points.boostersPrice[i])
                        {
                            Points.stars = Points.stars - Points.boostersPrice[i];
                            Points.boostersBought[i] = true;
                        }
                    }

                }
                else
                {
                    text = "Booster ägt";

                    if (GUILayout.Button(Points.boosters[i], doneStyle))
                    {

                    }
                }
                GUILayout.Label(text, priceStyle);
                GUILayout.Label(" ", emptyStyle);
            }


            GUILayout.EndArea();

            //if (Points.boosters.Count > 8)
            //    GUI.EndScrollView();

            //else
            GUILayout.EndArea();
        }
    }


}
