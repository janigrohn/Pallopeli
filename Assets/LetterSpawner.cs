﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LetterSpawner : MonoBehaviour {

    public Transform letterSpawnpoint0, letterSpawnpoint1, letterSpawnpoint2, letterSpawnpoint3, letterSpawnpoint4, letterSpawnpoint5, letterSpawnpoint6, letterSpawnpoint7, letterSpawnpoint8, letterSpawnpoint9, letterSpawnpoint10, letterSpawnpoint11, letterSpawnpoint12, letterSpawnpoint13, letterSpawnpoint14, letterSpawnpoint15;
    static int amountOfSpawnpoints = 16;    //MUUTA AINA KUN LISÄÄT SPAWNPOINTEJA

    public Transform letterA, letterB, letterC, letterD, letterE, letterF, letterG, letterH, letterI, letterJ, letterK, letterL, letterM, letterN, letterO, letterP, letterQ, letterR, letterS, letterT, letterU, letterV, letterW, letterX, letterY, letterZ, letterÅ, letterÄ, letterÖ;
    string[][] hintsAndWords;
    bool[] usedSpawnpoints = new bool[amountOfSpawnpoints];     // KAIKKI FALSEKSI KUN SANA SAATU VALMIIKSI

    int generatedRandomInt;
    bool readyForNextWord = true;

    string currentWord;
    List<string> wrongLetters= new List<string>();

    void Start () {

        for (int i = 0; i < amountOfSpawnpoints; i++)   // TEE MYÖS UPDATESSA KUN SANA ON SAATU VALMIIKSI
        {
            usedSpawnpoints[i] = false;
        }
        //Debug.Log("amountOfSpawnpoints=" + amountOfSpawnpoints);
        //Debug.Log(usedSpawnpoints[amountOfSpawnpoints - 1]);
        

        int numRows = 2;
        hintsAndWords = new string[numRows][];

        hintsAndWords[0] = new string[numRows];
        hintsAndWords[0][0] = "hint1 goes here";
        hintsAndWords[0][1] = "randomasd";

        hintsAndWords[1] = new string[numRows];
        hintsAndWords[1][0] = "hint2 goes here";
        hintsAndWords[1][0] = "lol";

        // LISÄÄ TÄHÄN VIHJEET JA SANAT
	}
	


	void Update () {
	    if (readyForNextWord)
        {
            SpawnLetters(hintsAndWords[0][1]);
            SpawnRandomWrongLetters(currentWord);
            readyForNextWord = false;

            //for (int i = 0; i < usedSpawnpoints.Length; i++)
            //{
            //    Debug.Log(i + " = " + usedSpawnpoints[i]);
            //}
        }
	}



    void SpawnRandomWrongLetters(string word)
    {
        word = word.Replace(" ", "");
        word = word.ToLower();
        List<string> alphabets = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö"};
        int amountOfWrongLetters;

        for (int j = 0; j < word.Length; j++)
        {
            for (int k = 0; k < alphabets.Count; k++)
            {
                if (alphabets[k] != null)
                    if (alphabets[k].Equals(word.Substring(j, 1)))
                    {
                        alphabets[k] = null;
                    }
            }
        }

        if (word.Length < 10)
            amountOfWrongLetters = 5;
        else
            amountOfWrongLetters = word.Length / 2;

        if (amountOfWrongLetters + word.Length < amountOfSpawnpoints)
        {
            for (int i = 0; i < amountOfWrongLetters; i++)
            {
                int randomIntForSpawnpoint = Random.Range(0, amountOfSpawnpoints);
                while (usedSpawnpoints[randomIntForSpawnpoint] == true)
                {
                    Debug.Log("Spawnpoint " + randomIntForSpawnpoint + " in use, creating new random");
                    randomIntForSpawnpoint = Random.Range(0, amountOfSpawnpoints);
                }
                    

                int randomIntForAlphabets = Random.Range(0, alphabets.Count);
                while (alphabets[randomIntForAlphabets] == null)
                {
                    randomIntForAlphabets = Random.Range(0, alphabets.Count);
                }

                GameObject variableForPrefab = (GameObject)Resources.LoadAssetAtPath("Assets/Aakkoset/" + alphabets[randomIntForAlphabets].ToUpper() +".obj", typeof(GameObject));
                Instantiate(variableForPrefab, SelectRandomSpawnpoint(randomIntForSpawnpoint), Quaternion.Euler(90.0f, 0, 90.0f));
                usedSpawnpoints[randomIntForSpawnpoint] = true;
                wrongLetters.Add(alphabets[randomIntForAlphabets]);
            }

        }
        else
        {
            Debug.LogError("Word is too long, not enough spawnpoints!");
        }
    }


    
    void SpawnLetters(string word)
    {
        currentWord = word;
        word = word.ToLower();
        word = word.Replace(" ", "");

        if (word.Length < amountOfSpawnpoints)
        {
            for (int i = 0; i < word.Length; i++)
            {

                switch (word.Substring(i, 1))
                {
                    case "a":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterA, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "b":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterB, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "c":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterC, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "d":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterD, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "e":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterE, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "f":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterF, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "g":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterG, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "h":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterH, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "i":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterI, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "j":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterJ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "k":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterK, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "l":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterL, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "m":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterM, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "n":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterN, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "o":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterO, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "p":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterP, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "q":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterQ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "r":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterR, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "s":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterS, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "t":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterT, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "u":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterU, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "v":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterV, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "w":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterW, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "x":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterX, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "y":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterY, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "z":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterZ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "å":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterÅ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "ä":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterÄ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    case "ö":
                        {
                            generatedRandomInt = Random.Range(0, amountOfSpawnpoints);
                            while (usedSpawnpoints[generatedRandomInt] == true)
                                generatedRandomInt = Random.Range(0, amountOfSpawnpoints);

                            Instantiate(letterÖ, SelectRandomSpawnpoint(generatedRandomInt), Quaternion.Euler(90.0f, 0, 90.0f));
                            usedSpawnpoints[generatedRandomInt] = true;
                            break;
                        }
                    default:
                        {
                            Debug.LogError("Couldn't identify character in index of " + i);
                            break;
                        }


                }

            }

        }
        else
        {
            Debug.LogError("Word is too long, not enough spawnpoints!");
        }
        

    }


    Vector3 SelectRandomSpawnpoint(int random)
    {
        switch(random)
        {
            case 0:
                return letterSpawnpoint0.position + new Vector3(0, 0.5f, 0);

            case 1:
                return letterSpawnpoint1.position + new Vector3(0, 0.5f, 0);

            case 2:
                return letterSpawnpoint2.position + new Vector3(0, 0.5f, 0);

            case 3:
                return letterSpawnpoint3.position + new Vector3(0, 0.5f, 0);

            case 4:
                return letterSpawnpoint4.position + new Vector3(0, 0.5f, 0);

            case 5:
                return letterSpawnpoint5.position + new Vector3(0, 0.5f, 0);

            case 6:
                return letterSpawnpoint6.position + new Vector3(0, 0.5f, 0);

            case 7:
                return letterSpawnpoint7.position + new Vector3(0, 0.5f, 0);

            case 8:
                return letterSpawnpoint8.position + new Vector3(0, 0.5f, 0);

            case 9:
                return letterSpawnpoint9.position + new Vector3(0, 0.5f, 0);

            case 10:
                return letterSpawnpoint10.position + new Vector3(0, 0.5f, 0);

            case 11:
                return letterSpawnpoint11.position + new Vector3(0, 0.5f, 0);

            case 12:
                return letterSpawnpoint12.position + new Vector3(0, 0.5f, 0);

            case 13:
                return letterSpawnpoint13.position + new Vector3(0, 0.5f, 0);

            case 14:
                return letterSpawnpoint14.position + new Vector3(0, 0.5f, 0);

            case 15:
                return letterSpawnpoint15.position + new Vector3(0, 0.5f, 0);

            default:
                Debug.LogWarning("Couldn't define spawnpoint from random int " + random);
                return letterSpawnpoint1.position;
        }
    }

}
