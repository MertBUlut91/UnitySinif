using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI playerName;


    void Start()
    {
        if (PlayerPrefs.HasKey("PositionX") || PlayerPrefs.HasKey("PositionY"))
        {
            player.transform.position = 
                new Vector2(PlayerPrefs.GetFloat("PositionX"), 
                PlayerPrefs.GetFloat("PositionY"));
        }
        playerName.text = PlayerPrefs.GetString("Name");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("PositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", player.transform.position.y);
        infoText.text = "Position Saved";
    }

    public void ResetPosition()
    {
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        infoText.text = "Position Deleted";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
