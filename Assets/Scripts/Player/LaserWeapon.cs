using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    private float timeBetweenShot;
    public float starttimeBetweenShot;
    public Transform ShotPoint;
    public Transform Weapon;


    private float timeCounter;
    private float startDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, offset);
    }

    // Update is called once per frame
    void Update()
    {
        // Wait a a little until weapon starts ( so player can center mouse in time )
        if (timeCounter < startDelay)
        {
            timeCounter += Time.deltaTime;
            return;
        }

        if (timeBetweenShot <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectile, ShotPoint.position, Weapon.rotation);
                timeBetweenShot = starttimeBetweenShot;
            }
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;
        }
    }
}
