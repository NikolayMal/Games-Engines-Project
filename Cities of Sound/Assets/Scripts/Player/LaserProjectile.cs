using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    // public AudioSource ShootingEffect;
    public LayerMask whatIsSolid;

    // public int damage;
    public GameObject destroyEffect;
    public GameObject tank;

    // Get cubeDeathCounter Value
    private static int cubeDeathCounter = movement.cubeDeathCounter;
    public static int deathCounterVariable = cubeDeathCounter;
    public static int weaponChooseCounter = movement.weaponChooseCounter;
    public static int waeponCounterVariable = weaponChooseCounter;
    movement wcc;

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
        Physics2D.IgnoreLayerCollision(4, 3, true);
        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log("HIT CUBE");
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
            waeponCounterVariable = 1;
            wcc = FindObjectOfType<movement>();
            wcc.wcCounter(waeponCounterVariable);
        }
        // Instantiate(explosionPrefab, position, rotation);
        //Destroy(gameObject);
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
