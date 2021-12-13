using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBetweenShot;
    public float starttimeBetweenShot;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenShot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBetweenShot = starttimeBetweenShot;
            }
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;

        }
    }
}