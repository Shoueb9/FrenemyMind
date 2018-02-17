using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipController : MonoBehaviour
{

    public float speed = 2.5f;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Text txtAmmo;
    public int initAmmo = 200;
    public Text txtScore;
    public int initScore;
    public AudioSource LazerFire;
    public AudioSource bombExplosion;
    public GameObject explody;

    private Rigidbody2D rb;
    private int ammoCount;

    // Use this for initialization
    void Start()
    {

        ammoCount = initAmmo;
        txtAmmo.text = "Ammo: " + ammoCount;

        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 motion = new Vector2(moveH, moveV);

        rb.AddForce(motion * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    void Fire()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            txtAmmo.text = "Ammo: " + ammoCount;
            LazerFire.Play();
            var bullet = (GameObject)Instantiate(bulletPrefab,
                bulletSpawn.position, bulletSpawn.rotation);

            Vector2 bulletMotion = new Vector2(10f, 0f);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("enemy"))
        {
            Instantiate(explody, transform.position, transform.rotation);
            bombExplosion.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag.Equals("enemyBullet"))
        {
            Instantiate(explody, transform.position, transform.rotation);
            bombExplosion.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag.Equals("boundary"))
        {
            Instantiate(explody, transform.position, transform.rotation);
            bombExplosion.Play();
            Destroy(gameObject);
        }

        if (other.tag.Equals("asteroid"))
        {
            Instantiate(explody, transform.position, transform.rotation);
            bombExplosion.Play();
            Destroy(gameObject);
        }
    }
}
