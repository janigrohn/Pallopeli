using UnityEngine;
using System.Collections;

public class BoosterScript : MonoBehaviour {

    GameObject ball;
    public float boosterPushForce = 50.0f;

    public static bool onBooster = false;

	void Start () {

        ball = GameObject.FindGameObjectWithTag("Player");
    }
	
	
	void Update () {
	
        if (onBooster)
        {
            ball.rigidbody.AddForce(transform.forward * boosterPushForce);
        }

	}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag.Equals("Plyaer"))
    //    {
    //        Debug.Log("Booster enter");
    //        onBooster = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag.Equals("Plyaer"))
    //    {
    //        Debug.Log("Booster exit");
    //        onBooster = false;
    //    }
    //}

}
