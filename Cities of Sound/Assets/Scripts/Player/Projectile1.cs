using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile1 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    // public AudioSource ShootingEffect;
    public LayerMask whatIsSolid;

    // public int damage;
    public GameObject destroyEffect;
    public GameObject baseWeapon;
    public GameObject LaserWeapon;
    public GameObject ExplosiveWeapon;

    // Get cubeDeathCounter Value
    private static int cubeDeathCounter = movement.cubeDeathCounter;
    public static int deathCounterVariable = cubeDeathCounter;

    movement dtc;

    // Start is called before the first frame update
    void Start()
    {
        //ShootingEffect = GetComponent<AudioSource>();
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ContactPoint contact = collision.contacts[0];
        // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Vector3 position = contact.point;
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            deathCounterVariable += 1;
            dtc = FindObjectOfType<movement>();
            dtc.dtcCounter(deathCounterVariable);
        }
        if (collision.gameObject.tag == "cubeWeapon")
        {
            Destroy(collision.gameObject);
            deathCounterVariable += 10;
            dtc = FindObjectOfType<movement>();
            dtc.dtcCounter(deathCounterVariable);
            baseWeapon.SetActive(false);
        }
        // Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);

    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
