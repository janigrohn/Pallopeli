using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

	
	void Start () {
	
	}
	
	
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Application.LoadLevel("level1");
        }
    }


}
