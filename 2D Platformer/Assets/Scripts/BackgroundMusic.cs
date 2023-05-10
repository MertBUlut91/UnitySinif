using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
   private static BackgroundMusic instance;
   AudioSource audioSource;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        BackGroundMusic();
    }

    void BackGroundMusic()
    {
        if (PauseMenu.isPause)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
}
