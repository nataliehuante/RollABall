using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private LevelController levelController;
    private GameView gameView;
    private Camera mainCamera;
    private GameStates.GameStatesType gameState;
    private int maxCollectiblesCount;
    private Sounds sounds;

    private void Start()
    {
        gameView = GetComponentInChildren<GameView>();
        levelController = FindObjectOfType<LevelController>();
        mainCamera = FindObjectOfType<Camera>();
        sounds = FindObjectOfType<Sounds>();

        gameState = GameStates.GameStatesType.OnMainMenu;
        StateUpdate(GameStates.GameStatesType.OnMainMenu);
       
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P)) && (gameState == GameStates.GameStatesType.GamePlaying))
        {
           StateUpdate(GameStates.GameStatesType.OnPauseMenu);
        }
    }

    public void CountCollectiblesInLevel(){
        maxCollectiblesCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        print(maxCollectiblesCount + " found");
    }


    
    private void OnGameWon()
    {
        gameState = GameStates.GameStatesType.GameWon;

        // Set the text value of our result text
        gameView.ShowGameWonScreen();

        // pause player functionality
        Time.timeScale = 0;

        sounds.PlayGameWon();

    }

    private void OnGameLost()
    {
        gameState = GameStates.GameStatesType.GameLost;

        // Set the text value of our result text
        gameView.ShowGameOverScreen();

        // pause player functionality
        Time.timeScale = 0;

        sounds.PlayGameLost();
    }

    private void OnPause()
    {
        // FIXME IF TIME ALLOWS
        // inactivate player movement
        
        // set pause screen
        gameView.ShowPauseScreen();
        // pause timer
        FindObjectOfType<SimpleTimer>().pauseTimer();
        // set time scale to zero 
        Time.timeScale = 0;
    }

    public void OnMainMenu()
    {
        // turn on main menu camera
        mainCamera.enabled = true;
        // destroy any levels if returning to main menu
        levelController.DestroyCurrentLevel();
        // show main screen
        gameView.ShowMainScreen();
        // reset current level
        levelController.SetCurrentLevel(0);

        sounds.PlayMainMenu();
        sounds.PauseInGame();
    }

    public void StartGame(int startingLevel)
    {
        // update gameState
        StateUpdate(GameStates.GameStatesType.GamePlaying);
        // turn off main menu camera
        mainCamera.enabled = false;
        // hide main menu, show in-game screen
        gameView.ShowGameScreen();
        // load level
        levelController.SetCurrentLevel(startingLevel-1);
        levelController.GoToNextLevel();
        Time.timeScale = 1;

        sounds.PauseMainMenu();
        sounds.PlayInGame();
    }

    public void ResumeGame()
    {
        // update gameState
        StateUpdate(GameStates.GameStatesType.GamePlaying);
        // hide pause menu, show in-game screen
        gameView.ShowGameScreen();
        // resume timer
        FindObjectOfType<SimpleTimer>().resumeTimer();
        // set time scale to one - pauses player movement
        Time.timeScale = 1;
    }


    public void StateUpdate(GameStates.GameStatesType newState)
    {
        //o nly if the game is in play, we can advance to win or lose
        if (gameState == GameStates.GameStatesType.GamePlaying)
        {
            switch (newState)
            {
                case GameStates.GameStatesType.GamePlaying: 
                    break;
                case GameStates.GameStatesType.GameWon:
                    gameState = GameStates.GameStatesType.GameWon;
                    OnGameWon();
                    break;
                case GameStates.GameStatesType.GameLost:
                    gameState = GameStates.GameStatesType.GameLost;
                    OnGameLost();
                    break;
                case GameStates.GameStatesType.OnPauseMenu:
                    gameState = GameStates.GameStatesType.OnPauseMenu;
                    OnPause();
                    break;
            }
        } else {
            switch (newState) 
            {
                case GameStates.GameStatesType.OnMainMenu: 
                    gameState = GameStates.GameStatesType.OnMainMenu;
                    OnMainMenu();
                    break;
                case GameStates.GameStatesType.GamePlaying: // only possibility: main menu -> game playing
                    gameState = GameStates.GameStatesType.GamePlaying;
                    break;
            }
        }
        
    }



    

    public void OnPickUpCollectible(int playerCollectibleCount)
    {
        gameView.SetCountText(playerCollectibleCount);
        // Check if our 'count' is equal to or exceeded our maxCollectibles count
        if (playerCollectibleCount >= maxCollectiblesCount)
        {
            levelController.GoToNextLevel();
        }
    }


    public void UpdateGameTimer(int timerCount)
    {
        gameView.SetTimerText(timerCount);
    }
}
