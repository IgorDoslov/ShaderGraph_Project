using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerControl : MonoBehaviour
{
    public Text timerText;
    public float startTimeValue = 10.0f;
    float startTime;
    public int winScore;
    public GameObject gameOverMenuUI;
    [Header("Pink Dog")]
    [SerializeField] SceneLoader sc;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameIsPaused = false;
        gameOverMenuUI.SetActive(false);
        startTime = startTimeValue;
        sc = GetComponent<SceneLoader>();

    }

    // Update is called once per frame
    void Update()
    {


        GameTimer();

    }

    void GameTimer()
    {
        float t = startTime - Time.timeSinceLevelLoad;

        string seconds = "Time: " + (t % 60).ToString("f2");

        timerText.text = seconds;

        if (t <= 0)
        {
            if (ScoreControl.platformScore >= winScore && ScoreControl.isPlatform)
            {
                sc.LoadWinSceneName();
            }
            else if (ScoreControl.shooterScore >= winScore && ScoreControl.isShootRunners)
            {
                sc.LoadWinSceneName();
            }
            else if (ScoreControl.goalScore >= winScore && ScoreControl.isScoreGoals)
            {
                sc.LoadWinSceneName();
            }
            else
            {
                timerText.text = "GAME OVER";
                PauseMenu.gameIsPaused = true;
                gameOverMenuUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }

}
