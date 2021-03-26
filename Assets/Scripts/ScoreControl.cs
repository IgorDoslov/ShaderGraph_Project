using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreControl : MonoBehaviour
{
    [HideInInspector] public static int shooterScore = 0;
    [HideInInspector] public static int goalScore = 0;
    [HideInInspector] public static int platformScore = 0;


    public Text scoreText;
    [SerializeField]
    public static bool isScoreGoals = false;
    public static bool isShootRunners = false;
    public static bool isPlatform = false;


    // Start is called before the first frame update
    void Start()
    {
        if (isShootRunners == true && isScoreGoals == false && isPlatform == false)
            shooterScore = 0;

        if (isScoreGoals == true && isShootRunners == false && isPlatform == false)
            goalScore = 0;

        if (isPlatform == true && isShootRunners == false && isScoreGoals == false)
            platformScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShootRunners == true)
            scoreText.text = "Score: " + shooterScore.ToString();
        if (isScoreGoals == true)
            scoreText.text = "Score: " + goalScore.ToString();


    }


}
