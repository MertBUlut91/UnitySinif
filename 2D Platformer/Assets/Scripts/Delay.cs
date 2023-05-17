using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    #region Singleton
    public static Delay Instance { get; private set; }
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

    LevelManager levelManager;
    [SerializeField] float delayTimer;
    public bool delayTime;

    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }

    public void DelayNewTime()
    {
        StartCoroutine(DelayTime());
    }
    public void FriesNewTime()
    {
        StartCoroutine(FriesTimer());
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(delayTimer);
        levelManager.PlayerRespawner();
    }
    private IEnumerator FriesTimer()
    {

        yield return new WaitForSeconds(delayTimer);

        if (levelManager.count<5)
        {
            levelManager.FriesRespawner();
        }
    }
}
