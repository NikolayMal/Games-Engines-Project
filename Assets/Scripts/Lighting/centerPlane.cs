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
        // Set Position (center based on size of array)
        transform.position = transform.position + new Vector3(x, 0, y);
        // Set Size
        transform.localScale = new Vector3((x * 0.75f), 1, (y * 0.75f));
    }
}
