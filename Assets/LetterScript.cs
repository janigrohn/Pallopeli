using UnityEngine;
using System.Collections;

public class LetterScript : MonoBehaviour {

    public Transform rightLetterDeathEffect;
    public Transform wrongLetterDeathEffect;

    public float distanceToBall = 2.0f;

    string letter;

    void Awake() {

        letter = LetterSpawner.letter;
	}
	
	
	void Update () {

        if (Vector3.Distance(GameObject.Find("Ball").transform.position, transform.position) < distanceToBall)
        {
            Debug.Log("Ball is close enough to letter " + letter);
            if (Input.GetKey(KeyCode.F))
            {
                if (LetterSpawner.currentWordLettersLeft.Contains(letter))
                {
                    Instantiate(rightLetterDeathEffect, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(wrongLetterDeathEffect, transform.position, Quaternion.identity);
                }

                Destroy(this.gameObject);
            }
            
        }

    }


}
