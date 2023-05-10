using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Update()
    {
        scoreText.text = "Score : " + ScoreManager.score.ToString();
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text ="High Score : " + ScoreManager.highScore.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        ScoreManager.score = 0;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
    }
}
