using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private int[,] gridArray;

    private float cellSize;

    Color brown = new Color(139f / 255f, 69f / 255f, 19f / 255f, 1f);

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        Debug.Log(width + " " + height);

        // Cycle through array
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "brown_cube" + x + " " + y;
                cube.GetComponent<Renderer>().material.color = brown;
                cube.transform.position = new Vector3(x, 0, y);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }


}
