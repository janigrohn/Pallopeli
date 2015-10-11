using UnityEngine;
using System.Collections;

public class LetterScript : MonoBehaviour {

    public Transform rightLetterDeathEffect;
    public Transform wrongLetterDeathEffect;
    GameObject ball;

    public float distanceToBall = 2.0f;

    string letter;

    void Awake () {

        ball = GameObject.FindGameObjectWithTag("Player");
        letter = LetterSpawner.letter;
	}
	
	
	void Update () {

        if (Vector3.Distance(ball.transform.position, transform.position) < distanceToBall)
        {
            //Debug.Log("Ball is close enough to letter " + letter);
            if (Input.GetKey(KeyCode.F))
            {
                if (LetterSpawner.currentWordLettersLeft.Contains(letter))
                {
                    Instantiate(rightLetterDeathEffect, transform.position, Quaternion.identity);
                    GUIScript.GotNewLetter(letter);
                }
                else
                {
                    Instantiate(wrongLetterDeathEffect, transform.position, Quaternion.identity);
                    // TODO: Miinuspisteitä
                }

                Destroy(this.gameObject);
            }
            
        }

    }


}
