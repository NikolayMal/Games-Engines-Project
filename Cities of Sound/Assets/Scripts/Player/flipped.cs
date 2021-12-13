using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipped : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.rotation = Quaternion.identity;
        }
        Debug.Log(transform.rotation.x);
    }
}