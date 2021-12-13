using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    // public AudioSource ShootingEffect;
    public LayerMask whatIsSolid;

    // public int damage;
    public GameObject destroyEffect;

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
        // if (hitInfo.collider != null)
        // {
        //     //ShootingEffect.Play();
        //     //if (Input.GetMouseButtonUp(0) == true)
        //     //{
        //     //    ShootingEffect.Stop();
        //     //}
        //     if (hitInfo.collider.CompareTag("Cube"))
        //     {
        //         Debug.Log("Block Must be Destroyed!");
        //     }
        //     DestroyProjectile();
        // }


        // transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);

        //transform.position += transform.up * speed * Time.deltaTime; Does same as line above 
    }

    void OnCollisionEnter(Collision collision)
    {
        // ContactPoint contact = collision.contacts[0];
        // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Vector3 position = contact.point;
        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log("HIT CUBE");
            Destroy(collision.gameObject);
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
