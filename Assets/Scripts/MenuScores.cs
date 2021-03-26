using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScores : MonoBehaviour
{
    public Text scoreGoalsScoreText;
    public Text shootRunnersScoreText;
    public Text PlatformPuzzleScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreGoalsScoreText.text = "Score: " + ScoreControl.goalScore.ToString();
        shootRunnersScoreText.text = "Score: " + ScoreControl.shooterScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
