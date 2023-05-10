using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance { get; private set; }
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

    private AudioSource audioSource;

    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip fall;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip falldeath;
    [SerializeField] private AudioClip enemydeath;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip door;



 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void FallSound()
    {
        audioSource.PlayOneShot(fall);
    }

    public void FallDeath()
    {
        audioSource.PlayOneShot(falldeath);
        Debug.Log("Fall death");
    }

    public void EnemyDeath()
    {
        audioSource.PlayOneShot(enemydeath);
        Debug.Log("Enemy death");
    }

    public void Attack()
    {
        audioSource.PlayOneShot(attack);
        Debug.Log("Enemy attack");
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(win);
        Debug.Log("Win Sound");
    }
    public void DoorSound()
    {
        audioSource.PlayOneShot(door);
        Debug.Log("Door Sound");
    }
}
