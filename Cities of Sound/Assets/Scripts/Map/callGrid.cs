using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callGrid : MonoBehaviour
{

    
    public static int x = 60;
    public static int y = 60;

    private void Start()
    {
        // Putting the Values to determine size of grid
        // These Values Must be Equal!
        if ( x == y)
        {
            gridCreate gridCreate = new gridCreate(x, y);
        }
    }
}
