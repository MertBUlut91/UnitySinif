using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    #region Singleton
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private UIManager uIManager;
    [SerializeField] Image[] playerLives;
    public int playerLife = 3;

    void Start()
    {
        uIManager = GameObject.Find("UiManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lives()
    {
        playerLife--;
        Destroy(playerLives[playerLife]);
        if (playerLife<1)
        {
            LevelManager.Instance.stopKnife = true;
            uIManager.GetComponent<Canvas>().enabled = true;
        }
    }
}
