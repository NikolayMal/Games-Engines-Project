using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    Rigidbody rb;

    public float movementSpeed;
    public float rotationSpeed;

    Vector2 move;

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
        // float moveForward = Input.GetAxis("Horizontal");

        // transform.position = transform.position + new Vector3(moveForward * movementSpeed * Time.deltaTime, 0, 0);


        // transform.Translate(0, 0, Input.GetAxis("Vertical") * speedForward * Time.deltaTime);
        // transform.Rotate(0, Input.GetAxis("Horizontal") * speedTurn * Time.deltaTime, 0);
    }

}
