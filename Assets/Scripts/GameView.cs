using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public CanvasGroup MainScreen;
    public CanvasGroup InstructionScreen;
    public CanvasGroup InGameScreen;
    public CanvasGroup LevelSelectScreen;
    public CanvasGroup PauseScreen;
    public CanvasGroup ResultScreen;

    public Text levelCountText;
    public Text collectibleCountText;
    public Text nextLevelText;
    public Text resultText;
    public Text timerText;
    public Text livesText;
    public Button playAgainButton;
    
    
    // // Start is called before the first frame update
    private void Start()
    {
        // Set the text property of our Result Text UI to an empty string, making the game over message blank
        resultText.text = "";
        // playAgainButton.enabled = false;
        collectibleCountText.text = "Count: 0";
        livesText.text = "Lives: 3";
        ShowMainScreen();
    }

    public void ShowGameScreen()
    {
        Show(InGameScreen);
        Hide(InstructionScreen);
        Hide(MainScreen);
        Hide(LevelSelectScreen);
        Hide(PauseScreen);
        Hide(ResultScreen);
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    public void SetCountText(int count)
    {
        // Update the text field of our 'countText' variable
        collectibleCountText.text = "Count: " + count;
    }

    public void SetTimerText(int count)
    {
        timerText.text = "Time: " + count;
    }

    public void UpdateGameView(int level)
    {
        print("calling update game view");
        levelCountText.text = "Level " + level;
        collectibleCountText.text = "Count: 0";
        livesText.text = "Lives: 3";
        if (level == 1){
            timerText.text = "Timer 1";
        }
        else if (level == 2) {
            timerText.text = "Timer 2";
        }
        else {
            timerText.text = "Timer 3";
        }
        
    }

    public void UpdateLivesView(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public IEnumerator ShowNextLevelMessage(int level, int delay)
    {
        nextLevelText.text = "Level " + level + "!";
        nextLevelText.enabled = true;
        yield return new WaitForSeconds(delay);
        nextLevelText.enabled = false;
    }

    public void ShowMainScreen()
    {
        Show(MainScreen);
        Hide(InstructionScreen);
        Hide(InGameScreen);
        Hide(LevelSelectScreen);
        Hide(PauseScreen);
        Hide(ResultScreen);
    }

    public void ShowPauseScreen()
    {
        Show(PauseScreen);
        Hide(InstructionScreen);
        Hide(InGameScreen);
        Hide(LevelSelectScreen);
        Hide(MainScreen);
        Hide(ResultScreen);
    }

    public void ShowGameOverScreen()
    {
        Hide(MainScreen);
        Hide(InstructionScreen);
        Hide(LevelSelectScreen);
        Hide(PauseScreen);
        Show(ResultScreen);
        resultText.text = "You Lose!";
        playAgainButton.enabled = true;
    }

    public void ShowInstructionScreen()
    {
        Show(InstructionScreen);
        Hide(MainScreen);
        Hide(LevelSelectScreen);
        Hide(InGameScreen);
        Hide(PauseScreen);
        Hide(ResultScreen);
    }

    public void ShowLevelSelectScreen()
    {
        Show(LevelSelectScreen);
        Hide(MainScreen);
        Hide(InstructionScreen);
        Hide(InGameScreen);
        Hide(PauseScreen);
        Hide(ResultScreen);
    }

    public void ShowGameWonScreen()
    {
        Hide(MainScreen);
        Hide(InstructionScreen);
        Hide(LevelSelectScreen);
        Hide(PauseScreen);

        resultText.text = "You Win!";
        playAgainButton.enabled = true;
        Show(ResultScreen);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    private void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

}
