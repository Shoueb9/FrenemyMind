using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletPlayerRotater : MonoBehaviour {

    private Text txtScore;

    private void Start()
    {
        txtScore =  GameObject.Find("textScore").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update () {

        gameObject.GetComponent<Transform>().Rotate(
            new Vector2(90f, 0f));

	}

    private void OnTriggerEnter2D(Collider2D other) //where bullets meet enemy spaceships then destroys them
    {
        Debug.Log("Bullet hit " + other.tag);
        if (other.tag.Equals("enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (string.IsNullOrEmpty(txtScore.text))
            {
                txtScore.text = "10";
            }
            else
            {
                txtScore.text = (System.Convert.ToInt32(txtScore.text) + 10).ToString();
            }
        }

        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
    }
}
