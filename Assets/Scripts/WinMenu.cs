using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinMenu : MonoBehaviour
{
    public Text winScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        if (ScoreControl.isShootRunners == true)
            winScoreText.text = "Score: " + ScoreControl.shooterScore.ToString();
        if (ScoreControl.isShootRunners == false)
            winScoreText.text = "Score: " + ScoreControl.goalScore.ToString();
    }
}
