using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadText;
    [SerializeField] TextMeshProUGUI infoText;
   
    
    void Update()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            loadText.text = "Your Name Is  " + PlayerPrefs.GetString("Name");

        }
        else
        {
            loadText.text = "No Registered Player";
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Name");
        infoText.text = "Data Deleted";
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Game()
    {
        SceneManager.LoadScene(2);
    }
}
