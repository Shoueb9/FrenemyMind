using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    /*void OnTriggerEnter2D(Collider2D other) //where bullets meet enemy spaceships then destroys them
    {
        Debug.Log("Bullet hit " + other.tag);
        if (other.tag.Equals("spaceship"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
    }*/
}
