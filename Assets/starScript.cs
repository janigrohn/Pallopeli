using UnityEngine;
using System.Collections;

public class starScript : MonoBehaviour {

    public bool isPickable = true;
    public Transform starDeathEffect;
    GameObject ball;

    public float distanceToBall = 2.0f;
    public float rotateSpeed = 100.0f;

    void Awake()
    {

        ball = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * rotateSpeed);

        if (isPickable && Vector3.Distance(ball.transform.position, transform.position) < distanceToBall)
        {
            //Debug.Log("Ball is close enough to star");
            if (Input.GetKey(KeyCode.F))
            {
                Instantiate(starDeathEffect, transform.position, Quaternion.identity);
                Points.stars++;

                GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
                if (stars.Length == 1)
                {
                    Points.achievementsDone[1] = true;
                }

                Destroy(this.gameObject);
            }

        }

    }
}
