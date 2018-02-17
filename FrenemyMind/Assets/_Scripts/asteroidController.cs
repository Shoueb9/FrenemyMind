using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour {

    public GameObject asteroidPrefab;
    private float speed;
    private float timeElapse;
    // Use this for initialization
    void Start()
    {

        speed = Random.Range(-100, -75);
        timeElapse = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timeElapse += Time.deltaTime;
        if (timeElapse % 10 < 0.1)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-3f, 3f), 0f, 0f);
            var asteroid = (GameObject)Instantiate(asteroidPrefab,
                transform.position + spawnOffset, transform.rotation);
            asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        //if (other.tag.Equals("boundary")) 
    }
}
