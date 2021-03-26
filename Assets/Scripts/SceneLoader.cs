using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string menuSceneName;
    public string scoreGoalsSceneName;
    public string shootRunnersSceneName;
    public string platformPuzzleSceneName;
    public string winSceneName;





    public void LoadMainMenu()
    {
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadScoreGoals()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ScoreControl.isShootRunners = false;
        ScoreControl.isScoreGoals = true;
        ScoreControl.isPlatform = false;
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(scoreGoalsSceneName);
    }

    public void LoadShootRunners()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ScoreControl.isShootRunners = true;
        ScoreControl.isScoreGoals = false;
        ScoreControl.isPlatform = false;

        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(shootRunnersSceneName);
    }

    public void LoadPlatformPuzzleSceneName()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ScoreControl.isShootRunners = false;
        ScoreControl.isScoreGoals = false;

        PauseMenu.gameIsPaused = false;
        ScoreControl.isPlatform = true;
        Time.timeScale = 1f;

        SceneManager.LoadScene(platformPuzzleSceneName);

    }

    public void LoadWinSceneName()
    {
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(winSceneName);

    }
}
