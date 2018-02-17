using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMover : MonoBehaviour {

    public Transform bg1;
    public Transform bg2;
    public int speed = 10;
    private Vector3 originalPosition;

        // Use this for initialization
        void Start () {

        originalPosition = new Vector3(bg2.position.x, bg2.position.y, bg2.position.z);

	}
	
	// Update is called once per frame
	void Update () {

        if (bg1.position.x <= - originalPosition.x)
            bg1.position = new Vector3 (originalPosition.x, originalPosition.y, originalPosition.z);

        if(bg2.position.x <= -originalPosition.x)
            bg2.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);

        bg1.position = new Vector3(bg1.position.x - speed * Time.deltaTime, bg1.position.y, bg1.position.z);
        bg2.position = new Vector3(bg2.position.x - speed * Time.deltaTime, bg2.position.y, bg2.position.z);

    }
}
