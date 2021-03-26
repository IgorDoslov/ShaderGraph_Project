using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public Button winButton;
    public SceneLoader sl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Win");

            winButton.gameObject.SetActive(true);
            ScoreControl.platformScore += 2;
            sl.LoadWinSceneName();

        }
    }
}
