using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRocket : MonoBehaviour
{
    public GameObject explosionEffect;
    public float delay = 0.001f;
    public float explosionForce = 10f;
    public float radius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if (rig != null)
            {
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }
        }
    }
    private void Explode()
    {

    }
}
