using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{
    public int timeLimit = 20;
    private float timeGamePlayingStarted;
    private GameController gameController;
    private bool isPaused = false;

    private void Awake()
    {
        // gameController = GetComponentInParent<GameController>();
        gameController = FindObjectOfType<GameController>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        timeGamePlayingStarted = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        float timeSinceGamePlayingStarted = Time.time - timeGamePlayingStarted;

        if (timeSinceGamePlayingStarted > timeLimit)
        {
            //Update game state on controller to be game lost
            gameController.StateUpdate(GameStates.GameStatesType.GameLost);
            //Turn off this component, disables functionality so we don't spam the GameController
            this.enabled = false;
        }
        
        if (!isPaused)
        {
            //cast time to an int
            int timerCount = (int) timeSinceGamePlayingStarted;

            int timeRemaining = timeLimit - timerCount;
            //Update Timer text on screen
            gameController.UpdateGameTimer(timeRemaining);
        }
        
    }

    // Set the time limit of the timer
    public void setTimeLimit(int newTimeLimit)
    {
        timeLimit = newTimeLimit;
    }

    // set the timer to pause (will not update)
    public void pauseTimer()
    {
        isPaused = true;
    }

    // set the timer to not paused (will not update)
    public void resumeTimer()
    {
        isPaused = false;;
    }
}
