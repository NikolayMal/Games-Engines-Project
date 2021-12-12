using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class gridCreate
{
    private int width;
    private int height;
    private int[,] gridArray;

    private int SizeX = callGrid.x / 2;
    private int SizeY = callGrid.y / 2;

    Material Building = Resources.Load("Building", typeof(Material)) as Material;
    Material testimg = Resources.Load("testimg", typeof(Material)) as Material;

    // Colors
    Color matColor = new Color(139f / 255f, 69f / 255f, 19f / 255f, 1f);
    Color matColor2 = new Color(70 / 255f, 160f / 255f, 70f / 255f, 1f);
    Color matColor3 = new Color(0f / 255f, 0f / 255f, 0f / 255f, 1f);
    Color matColor4 = new Color(180f / 255f, 240f / 255f, 0f / 200f, 1f);
    public gridCreate(int width, int height)
    {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];

        /* Array Value Meanings:
            1 = Where blocks CANT spawn
            2 = Where blocks CAN spawn
        */

        // Set all values in array to 1
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = 1;
            }
        }


        int randomH = 0;
        int randomW = 0;
        for (int i = 0; i < SizeX; i++)
        {
            // Set Values by Height
            for (int j = 0; j < gridArray.GetLength(0); j++)
            {
                gridArray[randomH, j] = 2;
            }
            randomH = Increment_randomH(randomH);
            if (randomH >= width)
            {
                break;
            }
            // Set Values by Width
            for (int w = 0; w < gridArray.GetLength(1); w++)
            {
                gridArray[w, randomW] = 2;
            }
            randomW = Increment_randomW(randomW);
            if (randomH >= width)
            {
                break;
            }
        }

        // Create Objects
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                if (gridArray[x, y] == 1)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "Building1high " + x + " " + y;
                    cube.GetComponent<Renderer>().material.color = matColor2;
                    cube.transform.position = new Vector3(x, 0.5f, y);
                }
                if (gridArray[x, y] == 2)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "Road " + x + " " + y;
                    cube.GetComponent<Renderer>().material.color = matColor3;
                    cube.transform.position = new Vector3(x, 0.5f, y);
                }
            }

        }
    }

    // Random Numbers
    private int Increment_randomH(int randomH)
    {
        int temp = 0;
        temp += Random.Range(2, 6); // Increment temp by random number between 2 and 6
        temp = temp + randomH;
        randomH = temp;
        return randomH;
    }
    private int Increment_randomW(int randomW)
    {
        int temp = 0;
        temp += Random.Range(2, 6); // Increment temp by random number between 2 and 6
        temp = temp + randomW;
        randomW = temp;
        return randomW;
    }
}