using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	
	void Start () {

        InvokeRepeating("DecreaseScore", 0.0f, 4.0f);
	}
	
	
	void Update () {
	
	}


    void DecreaseScore()
    {
        Points.score -= 20;
    }


}
