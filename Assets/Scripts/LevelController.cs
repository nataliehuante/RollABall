using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private PlayerController Player;
    public GameController GameController;

    public List<GameObject> levels;
    public Projectiles Projectiles;
    public GameView GameView;
    public bool GameOver = false;

    private GameObject levelGameObject;
    private int currentLevel = 0;



    public void GoToNextLevel()
    {
        currentLevel++;
        if (IsGameOver())
        {
            GameOver = true;
            DestroyProjectiles();
            // Screens.ShowGameWonScreen();
            // Sounds.Instance.PlayGameOver();
            return;
        }
        else
            LoadNextLevel();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public bool IsGameOver()
    {
        if (currentLevel == (levels.Count + 1))
            return true;
        return false;
    }

    public void DestroyCurrentLevel(){
       
        if ((levelGameObject != null) && (currentLevel != levels.Count))
        {
            Destroy(levelGameObject);
        }
    }

    private void LoadNextLevel()
    {
       
        if (currentLevel < levels.Count)
        {
            DestroyCurrentLevel();
            DestroyProjectiles();
            levelGameObject = CreateLevel();
            Player = FindObjectOfType<PlayerController>();
            Player.collectibleCount = 0;
            Player.lives = 3;
            
            // Sounds.Instance.PlayNextLevel();
            UpdateLevelReadouts();
            GameController.CountCollectiblesInLevel();
        }

        if (currentLevel >= levels.Count)
        {
            // Sounds.Instance.PlayGameWon();
            GameController.StateUpdate(GameStates.GameStatesType.GameWon);
        }

        
    }

    private void DestroyProjectiles()
    {
        Projectiles.DestroyAll("Projectile");
    }

    private void UpdateLevelReadouts()
    {
        GameView.UpdateGameView(currentLevel + 1);
    }

    private GameObject CreateLevel()
    {
        print("creating level " + (currentLevel+1));
        StartCoroutine(GameView.ShowNextLevelMessage(currentLevel+1, 2));
        return Instantiate(levels[currentLevel], new Vector3(377.5f, 462.5f, 0.0f), Quaternion.identity);
    }

}
