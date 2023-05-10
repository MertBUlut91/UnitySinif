using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
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
            uIManager.GetComponent<Canvas>().enabled = true;
        }
    }
}
