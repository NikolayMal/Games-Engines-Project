using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRocket : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionForce = 10f;
    public float radius = 5f;
    public GameObject DestroyMe;

    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
