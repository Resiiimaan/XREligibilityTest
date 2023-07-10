using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    int gridSpaces = -1;

    public int whoseTurn()
    {
        gridSpaces++;
        return gridSpaces % 2;
    }
}
