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
    Color black = new Color(0f / 255f, 0f / 255f, 0f / 255f, 1f);

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

        }
        for (int z = 0; z < SizeY; z++)
        {
            // Set Values by Width
            for (int w = 0; w < gridArray.GetLength(1); w++)
            {
                gridArray[w, randomW] = 2;
            }
            randomW = Increment_randomW(randomW);
            if (randomW >= height)
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
                    // Heights of Pillars
                    int eheightV = 0, rr = 0, heightV = 0;
                    // Call RandomRandom to decide whether its 
                    // a tall pillar or not
                    var cubeBottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubeBottom.name = "Building1high " + x + " " + y;
                    cubeBottom.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
                    cubeBottom.transform.position = new Vector3(x, 0.5f, y);
                    Rigidbody RigidBodycubeBottom = cubeBottom.AddComponent<Rigidbody>();
                    RigidBodycubeBottom.useGravity = false;


                    rr = randomrandom(rr);
                    if (rr < 7)
                    {
                        heightV = HeightValue(heightV);
                        for (int i = 1; i <= heightV; i++)
                        {
                            Debug.Log(i);
                            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cube.name = "Building1high " + x + " " + y;
                            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
                            cube.transform.position = new Vector3(x, 0.5f + i, y);
                            Rigidbody RigidBodyCube = cube.AddComponent<Rigidbody>();
                        }
                    }
                    else
                    {
                        eheightV = ExtremeHeightValue(eheightV);
                        for (int i = 1; i <= eheightV; i++)
                        {
                            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cube.name = "Building1high " + x + " " + y;
                            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
                            cube.transform.position = new Vector3(x, 0.5f + i, y);
                            Rigidbody RigidBodyCube = cube.AddComponent<Rigidbody>();
                        }
                    }
                }
                if (gridArray[x, y] == 2)
                {
                    var cubeN = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubeN.name = "Path " + x + " " + y;
                    cubeN.GetComponent<Renderer>().material.color = black;
                    cubeN.transform.position = new Vector3(x, 0.5f, y);
                }
            }

        }
    }

    // Random Numbers
    private int Increment_randomH(int randomH)
    {
        int temp = 0;
        temp += Random.Range(1, 4); // Increment temp by random number between 2 and 6
        temp = temp + randomH;
        randomH = temp;
        return randomH;
    }
    private int Increment_randomW(int randomW)
    {
        int temp = 0;
        temp += Random.Range(1, 5); // Increment temp by random number between 2 and 6
        temp = temp + randomW;
        randomW = temp;
        return randomW;
    }

    private int HeightValue(int heightV)
    {
        int temp = 0;
        temp += Random.Range(2, 4); // Increment temp by random number between 2 and 6
        temp = temp + heightV;
        heightV = temp;
        return heightV;
    }

    private int ExtremeHeightValue(int eheightV)
    {
        int temp = 0;
        temp += Random.Range(2, 9); // Increment temp by random number between 2 and 6
        temp = temp + eheightV;
        eheightV = temp;
        return eheightV;
    }

    private int randomrandom(int rr)
    {
        int temp = 0;
        temp += Random.Range(0, 10); // Increment temp by random number between 2 and 6
        temp = temp + rr;
        rr = temp;
        return rr;
    }

}