using UnityEngine;
using System.Collections;

public class DeathAreaScript : MonoBehaviour {

    GameObject ball;
    public Transform ballSpawnpoint;

	void Start () {

        ball = GameObject.FindGameObjectWithTag("Player");
    }
	
	
	void Update () {
	

	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            ball.transform.position = ballSpawnpoint.position;

            Points.score = Points.score - 2000;
            GUIScript.ShowPointsChange(-2000);
        }
    }


}
