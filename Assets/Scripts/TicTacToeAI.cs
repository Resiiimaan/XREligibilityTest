using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

public enum TicTacToeState{none, _oPrefab, _xPrefab }

[System.Serializable]


public class WinnerEvent : UnityEvent<int>
{
    // [SerializeField] private int _gridSize = 3;

    TicTacToeState[] boardState;

    public TicTacToeState playerState = TicTacToeState._oPrefab;
    TicTacToeState aiState = TicTacToeState._xPrefab;

    public void EndTurn()
    {
        //Top Row 
        if (boardState[0] == playerState && boardState[1]
            == playerState && boardState[2] == playerState)
        {
            GameOver();
        }

        //Middle Row
        if (boardState[3] == playerState && boardState[4]
            == playerState && boardState[5] == playerState)
        {
            GameOver();
        }

        //Bottom Row
        if (boardState[6] == playerState && boardState[7]
            == playerState && boardState[8] == playerState)
        {
            GameOver();
        }

        //First Column
        if (boardState[0] == playerState && boardState[3]
            == playerState && boardState[6] == playerState)
        {
            GameOver();
        }

        //Middle Column
        if (boardState[1] == playerState && boardState[4]
            == playerState && boardState[7] == playerState)
        {
            GameOver();
        }

        //Right Column
        if (boardState[2] == playerState && boardState[5]
            == playerState && boardState[8] == playerState)
        {
            GameOver();
        }

        //First Diagonal
        if (boardState[0] == playerState && boardState[4]
            == playerState && boardState[8] == playerState)
        {
            GameOver();
        }

        //Second Diagonal
        if (boardState[2] == playerState && boardState[4]
            == playerState && boardState[6] == playerState)
        {
            GameOver();
        }

        //Top Row
        if (boardState[0] == aiState && boardState[1]
            == aiState && boardState[2] == aiState)
        {
            GameOver();
        }

        //Middle Row
        if (boardState[3] == aiState && boardState[4]
            == aiState && boardState[5] == aiState)
        {
            GameOver();
        }

        //Bottom Row
        if (boardState[6] == aiState && boardState[7]
            == aiState && boardState[8] == aiState)
        {
            GameOver();
        }

        //First Column
        if (boardState[0] == aiState && boardState[3]
            == aiState && boardState[6] == aiState)
        {
            GameOver();
        }

        //Middle Column
        if (boardState[1] == aiState && boardState[4]
            == aiState && boardState[7] == aiState)
        {
            GameOver();
        }

        //Right Column
        if (boardState[2] == aiState && boardState[5]
            == aiState && boardState[8] == aiState)
        {
            GameOver();
        }

        //First Diagonal
        if (boardState[0] == aiState && boardState[4]
            == aiState && boardState[8] == aiState)
        {
            GameOver();
        }

        //Second Diagonal
        if (boardState[2] == aiState && boardState[4]
            == aiState && boardState[6] == aiState)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        for (int i = 0; i < boardState.Length; i++)
        {
       //     boardState[i].GetComponent<EndMessage>().OnGameEnded = false;
        }
    }
}

public class TicTacToeAI : MonoBehaviour
{

	int _aiLevel;


	[SerializeField]
	private bool _isPlayerTurn;

    [SerializeField]
    private GameObject[] gamePrefabs;

    public UnityEvent onGameStarted;

    public TicTacToeState playerState = TicTacToeState._oPrefab;
    TicTacToeState aiState = TicTacToeState._xPrefab;

    //Call This event with the player number to denote the winner
    public WinnerEvent onPlayerWin;

	ClickTrigger[,] _triggers;
	
	private void Awake()
	{
		if(onPlayerWin == null)
        {
			onPlayerWin = new WinnerEvent();
		}
	}

	public void StartAI(int AILevel){
		_aiLevel = AILevel;
		StartGame();
	}

	public void RegisterTransform(int myCoordX, int myCoordY, ClickTrigger clickTrigger)
	{
		_triggers[myCoordX, myCoordY] = clickTrigger;
	}

	private void StartGame()
	{
		_triggers = new ClickTrigger[3,3];
		onGameStarted.Invoke();
	}

	// Turns between Player and AI
	public void PlayerSelects(int coordX, int coordY){

		SetVisual(coordX, coordY, playerState);
	}
		public void AiSelects(int coordX, int coordY){

		SetVisual(coordX, coordY, aiState);
	}

	private void SetVisual(int coordX, int coordY, TicTacToeState targetState)
	{
       for (int i = 0; i < 2; i++)
		{
            gameIndex = Random.Range(0, gamePrefabs.Length);
        }
      //      Instantiate(
	//		targetState == TicTacToeState._oPrefab,
	//		_triggers[coordX, coordY].transform.position,
	//		Quaternion.identity
	//	);
	}


   
    int gameIndex;
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
}
