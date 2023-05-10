using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;

        }
    }
    #endregion

    public TextMeshProUGUI scoreText;
    public static int score;
    public static int highScore;

    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();

        if (highScore<score)
        {
            PlayerPrefs.SetInt("High Score", score);
        }
    }
}
