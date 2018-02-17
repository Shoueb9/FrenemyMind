using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    public GameObject enemyCraftPrefab;
    public Transform enemyBulletSpawn;
    public GameObject bulletEnemyPrefab;
    public AudioSource EnemyBlast;
    private float speed;
    private float timeElapsed;
    // Use this for initialization
    void Start()
    {

        speed = Random.Range(-75, -50);
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timeElapsed += Time.deltaTime;
        if (timeElapsed % 8 < 0.1)
        {
            Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
            var enemy = (GameObject)Instantiate(enemyCraftPrefab,
                transform.position + spawnOffset, transform.rotation);
            var enemyB = (GameObject)Instantiate(bulletEnemyPrefab,
                transform.position + spawnOffset + new Vector3(-1f, 0f, 0f), transform.rotation);

            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
            enemyB.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed - 60, 0f));
            EnemyBlast.Play();

        }
    }

    void enemyFire()
    {
        var enemyBullet = (GameObject)Instantiate(bulletEnemyPrefab,
                enemyBulletSpawn.position, enemyBulletSpawn.rotation);

        Vector2 bulletMotion = new Vector2(-6f, 0f);
        enemyBullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        //if (other.tag.Equals("boundary")) 
    }
}
