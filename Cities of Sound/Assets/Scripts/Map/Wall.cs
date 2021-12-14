using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    private int SizeX = callGrid.x;
    private int SizeY = callGrid.y;

    // Start is called before the first frame update
    void Start()
    {
        int gap = 10;
        for (int row = 0; row < 20; row++)
        {
            for (int col = 0; col < SizeY + gap; col++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.transform.position = transform.TransformPoint(new Vector3(col - (gap / 2) - 1, 7f + row, 0));
                wall.transform.rotation = transform.rotation;
                wall.GetComponent<Renderer>().material.color = Color.red;
                // wall.AddComponent<Rigidbody>();
                wall.transform.parent = this.transform;
                // wall.GetComponent<Rigidbody>().mass = 1000;
                wall.layer = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
