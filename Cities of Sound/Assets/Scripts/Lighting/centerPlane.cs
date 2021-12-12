using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerPlane : MonoBehaviour
{
    private int x = callGrid.x / 2;
    private int y = callGrid.y / 2;

    // Start is called before the first frame update
    void Start()
    {
        // Set Position
        transform.position = transform.position + new Vector3(x, 0f, y);
        // Set Size
        Vector3 local = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
