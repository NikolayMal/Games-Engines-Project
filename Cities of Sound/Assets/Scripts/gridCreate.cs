using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class gridCreate
{
    private int width;
    private int height;
    private int[,] gridArray;

    // Colors
    Color matColor = new Color(139f / 255f, 69f / 255f, 19f / 255f, 1f);
    Color matColor2 = new Color(70 / 255f, 160f / 255f, 70f / 255f, 1f);

    Color matColor3 = new Color(0f / 255f, 0f / 255f, 0f / 255f, 1f);

    public gridCreate(int width, int height)
    {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];

        /* Array Value meanings: 
            1 = Building
            2 = Road
            3 = CrossRoad */

        // Set Array to 1 ( Values for Building )
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = 1;
            }
        }
        // Create Roads by Height
        int r = 0;
        for (int i = 0; i < 50; i++) // 50 is half of the 100 used to create grid
        {
            for (int h = 0; h < gridArray.GetLength(0); h++)
            {
                gridArray[r, h] = 2;
            }
            r = RoadIncrementValueH(r);
            if (r >= width) break; // If exceeds grid width break;
        }
        // Create Roads by Width
        int r2 = 0;
        for (int j = 0; j < 50; j++) // 50 is half of the 100 used to create grid
        {
            for (int w = 0; w < gridArray.GetLength(1); w++)
            {
                if (gridArray[w, r2] == 1)
                {
                    // Horizontal & Vertical Roads
                    gridArray[w, r2] = 2;
                }
                else if (gridArray[w, r2] == 2)
                {
                    // Set to 3 for Crossroads
                    gridArray[w, r2] = 3;
                }
            }
            r2 = RoadIncrementValueW(r2);
            if (r2 >= height) break; // If exceeds grid height break;
        }
        // x = x value
        // y = z value  [in 3D world]
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                if (gridArray[x, y] == 1)
                {
                    int bHV = 0;

                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "BuildingCube " + x + " " + y;
                    cube.GetComponent<Renderer>().material.color = matColor;
                    cube.transform.position = new Vector3(x, 0.5f, y);
                    // calls function to determine height
                    bHV = buildingHeightValue(bHV);
                    for (int i = 0; i < bHV; i++)
                    {
                        var cubeN = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cubeN.name = "BuildingCubeHeight " + (x + i) + " " + (y + i);
                        cubeN.GetComponent<Renderer>().material.color = matColor;
                        cubeN.transform.position = new Vector3(x, 0.5f + i, y);
                    }
                }
                if (gridArray[x, y] == 2)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "RoadCube " + x + " " + y;
                    cube.GetComponent<Renderer>().material.color = matColor2;
                    cube.transform.position = new Vector3(x, 0.5f, y);
                }
                if (gridArray[x, y] == 3)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "CrossRoadCube " + x + " " + y;
                    cube.GetComponent<Renderer>().material.color = matColor3;
                    cube.transform.position = new Vector3(x, 0.5f, y);
                }
            }
        }


    }
    // Creating roads, leaving random amounts of buildings in between
    private int RoadIncrementValueH(int r)
    {
        int temp = 0;
        temp += Random.Range(2, 6); // Increment temp by random number between 2 and 6
        temp = temp + r;
        r = temp;
        return r;
    }
    private int RoadIncrementValueW(int r2)
    {
        int temp = 0;
        temp += Random.Range(2, 6); // Increment temp by random number between 2 and 6
        temp = temp + r2;
        r2 = temp;
        return r2;
    }

    private int buildingHeightValue(int bHV)
    {
        int temp = 0;
        temp = Random.Range(1, 7);
        bHV = temp;

        return bHV;
    }
}
