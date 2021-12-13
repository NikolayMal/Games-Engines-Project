using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    private float timeBetweenShot;
    public float starttimeBetweenShot;

    public Transform Weapon;
    public float WeaponSpeed;
    private float WeaponAngle;
    public Transform ShotPoint;
    public float ShotPointSpeed;
    private float ShotPointAngle;

    private float timeCounter;
    private float startDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, ShotPoint.position, transform.rotation);
                timeBetweenShot = starttimeBetweenShot;
            }
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;

        }

        /*
            Weapon Movement was taken and adjusted from this video:
            https://www.youtube.com/watch?v=gaDFNCRQr38&ab_channel=OnlineCodeCoaching
        */
        // Rotation ( to follow mouse )
        // Rotate Weappon
        WeaponAngle -= Input.GetAxis("Mouse X") * WeaponSpeed * -Time.deltaTime;
        WeaponAngle = Mathf.Clamp(WeaponAngle, -90, 90);
        Weapon.localRotation = Quaternion.AngleAxis(WeaponAngle, Vector3.up);
        // Rotate ShotPoint
        ShotPointAngle -= Input.GetAxis("Mouse Y") * ShotPointSpeed * -Time.deltaTime;
        ShotPointAngle = Mathf.Clamp(ShotPointAngle, -40, 40);
        ShotPoint.localRotation = Quaternion.AngleAxis(ShotPointAngle, Vector3.left);
    }
}
