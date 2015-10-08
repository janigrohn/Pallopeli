using UnityEngine;
using System.Collections;

public class LetterSpawner : MonoBehaviour {

    public Transform letterSpawnpoint1, letterSpawnpoint2, letterSpawnpoint3, letterSpawnpoint4, letterSpawnpoint5;
    int amountOfSpawnpoints = 5;
    public Transform letterA, letterB, letterC, letterD, letterE, letterF, letterG, letterH, letterI, letterJ, letterK, letterL, letterM, letterN, letterO, letterP, letterQ, letterR, letterS, letterT, letterU, letterV, letterW, letterX, letterZ, letterÅ, letterÄ, letterÖ;
    string[][] hintsAndWords;
    bool[] usedSpawnpoints;     // KAIKKI FALSEKSI KUN SANA SAATU VALMIIKSI

    int randomInt;
    bool readyForNextWord = true;   // EI VIELÄ KÄYTETTY

    void Start () {

        for (int i = 0; i < amountOfSpawnpoints; i++)   // TEE MYÖS UPDATESSA KUN SANA ON SAATU VALMIIKSI
        {
            usedSpawnpoints[i] = false;
        }
        

        int numRows = 2;
        hintsAndWords = new string[numRows][];

        hintsAndWords[0] = new string[numRows];
        hintsAndWords[0][0] = "hint1 goes here";
        hintsAndWords[0][1] = "word";

        hintsAndWords[1] = new string[numRows];
        hintsAndWords[1][0] = "hint2 goes here";
        hintsAndWords[1][0] = "lol";
	}
	

	void Update () {
	    // TODO: SpawnLetters(hintsAndWords[i][j]);
	}

    
    void SpawnLetters(string word)
    {
        word = word.ToLower();

        for (int i = 0; i < word.Length; i++)
        {

            int amountOfNotUsedSpawnpoints = 0;
            for (int j = 0; j < usedSpawnpoints.Length; j++)
            {
                if (usedSpawnpoints[j] != false)
                {
                    amountOfNotUsedSpawnpoints++;
                }
            }
            randomInt = GetRandom(amountOfNotUsedSpawnpoints);

            switch (word.Substring(i, 1))
            {
                case "a":
                    {
                        Instantiate(letterA, SelectRandomSpawnpoint(randomInt), Quaternion.identity);
                        usedSpawnpoints[randomInt] = true;
                        break;
                    }
                case "b":
                    {
                        break;
                    }
                default:
                    {
                        Debug.Log("Couldn't identify character in index of " + i);
                        break;
                    }
                    
                    
            }
        }

    }


    int GetRandom(int amountOfNotUsedSpawnpoints)
    {
        return Random.Range(0, amountOfNotUsedSpawnpoints);
    }


    Vector3 SelectRandomSpawnpoint(int random)
    {
        switch(random)
        {
            case 1:
                return letterSpawnpoint1.position;

            case 2:
                return letterSpawnpoint2.position;

            case 3:
                return letterSpawnpoint3.position;

            case 4:
                return letterSpawnpoint4.position;

            case 5:
                return letterSpawnpoint5.position;

            default:
                Debug.Log("Couldn't define spawnpoint from random int " + random);
                return letterSpawnpoint1.position;
        }
    }

}
