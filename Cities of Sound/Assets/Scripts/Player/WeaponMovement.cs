using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform ShotPoint;
    public float movementSpeed;
    public float rotationSpeed;

    public Transform Weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Weappon Using Arrow Keys

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Weapon.Rotate(0f, movementSpeed * rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Weapon.Rotate(0f, -movementSpeed * rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ShotPoint.Rotate(-movementSpeed * rotationSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ShotPoint.Rotate(movementSpeed * rotationSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
