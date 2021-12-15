using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class center : MonoBehaviour
{
    private int x = callGrid.x / 2;
    private int y = callGrid.y / 2;

    // Start is called before the first frame update
    void Start()
    {
        // Center Based on Grid Size
        transform.position = transform.position + new Vector3(x, 15, y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
