using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class WinPanelScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score : " + ScoreManager.score.ToString();

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
        int score = ScoreManager.score;
        scoreText.text = score.ToString();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
