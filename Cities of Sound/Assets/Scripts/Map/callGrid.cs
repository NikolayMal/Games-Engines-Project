using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callGrid : MonoBehaviour
{
    public static int x = 40;
    public static int y = 40;

    private void Start()
    {
        // Putting the Values to determine size of grid
        gridCreate gridCreate = new gridCreate(x, y);
    }
}
