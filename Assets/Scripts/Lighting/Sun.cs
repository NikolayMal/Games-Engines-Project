using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    // Now the MOON (white light)

    // Rotates around center point which is calculated in center.cs
    public GameObject target;
    private int x = callGrid.x / 2;
    private int y = callGrid.y / 2;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + new Vector3(x + 50, 15, y + 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 5 * Time.deltaTime);
    }
}
