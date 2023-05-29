using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] Toggle check;

    void Start()
    {
        if (PlayerPrefs.HasKey("Check"))
        {
            check.isOn = PlayerPrefs.GetInt("Check") == 1;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputField.text);
        PlayerPrefs.SetInt("Check", check.isOn ? 1 : 0);
        infoText.text = "Data Saved";
    }
    public void Next()
    {
        SceneManager.LoadScene(1);
    }
    public void Default()
    {
        PlayerPrefs.DeleteAll();
    }
}
