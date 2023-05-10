using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause;
    [SerializeField] GameObject pauseMenu;
    PlayerHealth playerHealth;
    [SerializeField] GameObject winPanel;


    private void Start()
    {
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && winPanel.activeSelf == false && playerHealth.playerLife>0 )
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        LevelManager.canMove = false;
        isPause = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        LevelManager.canMove = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
        Time.timeScale = 1;
        LevelManager.canMove = false;
        isPause = false;

    }

}
