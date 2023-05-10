using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        SoundManager.Instance.DoorSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winPanel.SetActive(true);
        collision.gameObject.SetActive(false);
        SoundManager.Instance.WinSound();
    }

}
