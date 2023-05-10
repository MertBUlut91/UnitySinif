using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Update()
    {
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score : " + ScoreManager.highScore.ToString();
    }
    public void StartButton()
    {

        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
