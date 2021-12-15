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
    public static int weaponChooseCounter = 0;
    public GameObject baseWeapon;
    public GameObject LaserWeapon;
    public GameObject ExplosiveWeapon;

    int routineCheck = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wcCounter(0);
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

        // Ensure that Routine isnt called more than once.
        if (dtc >= 50 && routineCheck == 0)
        {
            CancelInvoke();
            InvokeRepeating("CubeRainRoutine", 1f, 5f);
            routineCheck += 1;
        }
        return dtc;
    }

    public int wcCounter(int wcc)
    {
        weaponChooseCounter += wcc;

        if (weaponChooseCounter == 0)
        {
            baseWeapon.SetActive(true);
        }
        if (weaponChooseCounter == 1)
        {
            baseWeapon.SetActive(false);
            LaserWeapon.SetActive(true);

        }
        if (weaponChooseCounter == 2)
        {
            LaserWeapon.SetActive(false);
            ExplosiveWeapon.SetActive(true);

        }
        return wcc;
    }

    public void CubeRainRoutine()
    {
        float randomGridx = 0;
        float randomGridy = 0;
        for (int i = 0; i < 4; i++)
        {
            randomGridx = randomGridX(randomGridx);
            randomGridy = randomGridY(randomGridy);
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "cube " + i;
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
            cube.transform.position = new Vector3(randomGridx, 10.5f, randomGridy);
            cube.tag = "Cube";
            Rigidbody RigidBodyCube = cube.AddComponent<Rigidbody>();
            cube.layer = 6;
        }
    }

    private float randomGridX(float randomGridx)
    {
        float x = callGrid.x;
        float y = callGrid.y;
        randomGridx = Random.Range(0, x);
        return randomGridx;
    }

    private float randomGridY(float randomGridy)
    {
        float x = callGrid.x;
        float y = callGrid.y;
        randomGridy = Random.Range(0, y);
        return randomGridy;
    }

}
