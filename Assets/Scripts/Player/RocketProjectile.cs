using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;
    public GameObject explosion;

    // Get cubeDeathCounter Value
    private static int cubeDeathCounter = movement.cubeDeathCounter;
    public static int deathCounterVariable = cubeDeathCounter;

    public static int weaponChooseCounter = movement.weaponChooseCounter;
    public static int waeponCounterVariable = weaponChooseCounter;
    private GameObject InstantiatedExplosionParticle;
    movement dtc;
    movement wcc;

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
            waeponCounterVariable = 1;
            deathCounterVariable += 1;
            wcc = FindObjectOfType<movement>();
            wcc.wcCounter(waeponCounterVariable);
        }
        ExplosionRocket();
        DestroyProjectile();
    }

    void DestroyProjectile()
    {

        Destroy(gameObject);
    }

    void ExplosionRocket()
    {
        // Explosion Particle
        InstantiatedExplosionParticle = (GameObject)Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(InstantiatedExplosionParticle, .2f);
        // Create Explosion 
        Instantiate(explosion, transform.position, Quaternion.identity);
        DestroyProjectile();
    }
}
