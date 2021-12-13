using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float WeaponSpeed;
    private float WeaponAngle;
    public Transform ShotPoint;
    public float ShotPointSpeed;
    private float ShotPointAngle;

    public Transform Weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
