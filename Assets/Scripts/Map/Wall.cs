using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private int SizeX = callGrid.x;
    private int SizeY = callGrid.y;

    private static int cubeDeathCounter = movement.cubeDeathCounter;
    public static int deathCounterVariable = cubeDeathCounter;
    public static int weaponChooseCounter = movement.weaponChooseCounter;
    public static int waeponCounterVariable = weaponChooseCounter;

    movement dtc;
    movement wcc;


    // Start is called before the first frame update
    void Start()
    {
        int gap = 10;

        // Loops through to generate all 4 sides 
        for (int i = 0; i < 4; i++)
        {
            // Generate Row and Columns of Wall
            for (int row = 0; row < 20; row++)
            {
                for (int col = 0; col < SizeY + gap; col++)
                {
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (i == 0)
                    {
                        wall.transform.position = transform.TransformPoint(new Vector3(col - (gap / 2) - 1, 7f + row, 0));

                    }
                    if (i == 1)
                    {   // z + ( to build in opposite direction of  i === 0)
                        wall.transform.position = transform.TransformPoint(new Vector3(col - (gap / 2) - 1, 7f + row, SizeX + gap));

                    }
                    if (i == 2)
                    {
                        wall.transform.position = transform.TransformPoint(new Vector3(-gap + 3, 7f + row, col + 1));

                    }
                    if (i == 3)
                    {
                        wall.transform.position = transform.TransformPoint(new Vector3(gap + SizeX - 6, 7f + row, col + 1));
                    }

                    wall.transform.rotation = transform.rotation;
                    wall.GetComponent<Renderer>().material.color = Color.red;
                    // wall.AddComponent<Rigidbody>();
                    wall.transform.parent = this.transform;
                    // wall.GetComponent<Rigidbody>().mass = 1000;
                    wall.layer = 1;
                    // wall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY ;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ContactPoint contact = collision.contacts[0];
        // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Vector3 position = contact.point;
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            deathCounterVariable += 1;
            dtc = FindObjectOfType<movement>();
            dtc.dtcCounter(deathCounterVariable);
        }
        if (collision.gameObject.tag == "cubeWeapon")
        {
            Destroy(collision.gameObject);
            deathCounterVariable += 10;
            dtc = FindObjectOfType<movement>();
            dtc.dtcCounter(deathCounterVariable);
            waeponCounterVariable = 1;
            wcc = FindObjectOfType<movement>();
            wcc.wcCounter(waeponCounterVariable);
        }
        // Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
