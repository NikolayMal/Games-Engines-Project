using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class movement : MonoBehaviour
{
    Rigidbody rb;

    public float movementSpeed;
    public float rotationSpeed;

    public TextMeshProUGUI cubeDeathText;
    private int deathCounterText = 0;
    public static int cubeDeathCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            transform.Translate(0.0f, 0f, movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            transform.Translate(0.0f, 0f, -movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(0f, movementSpeed * rotationSpeed * Time.deltaTime, 0f);

        }

        if (Input.GetKey(KeyCode.A))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(0f, -movementSpeed * rotationSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.None))
        {
            rb.velocity = transform.forward * 0;
        }

        // Change counter text
        cubeDeathText.text = "Cubes Destroyed: " + deathCounterText.ToString();
    }


    // Get Value of death counter from Projectile1 script
    public int dtcCounter(int dtc)
    {
        deathCounterText = dtc;
        return dtc;
    }

}
