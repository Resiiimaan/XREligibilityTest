using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieces : MonoBehaviour
{
    public GameObject[] gamePrefabs;
    int gameIndex;
    GameObject gridSpaces;
    bool unplayed = true;


    void OnMouseDown()
    {
        // Make sure no piece can be put on top ofanother piece
        if (unplayed)
        {
            for (int i = 0; i < 2; i++)
            {
                gameIndex = Random.Range(0, gamePrefabs.Length);
                // gameIndex = gridSpaces.GetComponent<PlayerTurn>().WhoseTurn();
            }

            Instantiate(gamePrefabs[gameIndex], transform);
            unplayed = false;
        }

    }

    public void EndTurn()
    {
        //TODO: Add code that ends the current turn
    }


    private void Awake()
    {
        GameObject gamePrefabs = GetComponent<GameObject>();
        gridSpaces = GameObject.Find("GridSpaces");
    }
}
