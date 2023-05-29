using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }
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

        PlayerSpawner();
        FriesSPawner();
    }
    #endregion

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject friesPrefab;
    [SerializeField] Transform friesSpawnPos;
    public int count;
    [SerializeField] GameObject door;
    [SerializeField] GameObject runText;

    [Header("Knife")]
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float minSpawn;
    [SerializeField] float maxSpawn;
    [SerializeField] float startSpawn;
    [SerializeField] float startWait;
    public bool stopKnife;
    [SerializeField] float xPos;

    public static bool canMove;


    private void Start()
    {
        StartCoroutine(KnifeSpawner());
    }
    private void Update()
    {
        if (count==5)
        {
            door.SetActive(true);
            runText.SetActive(true);
            stopKnife = true;
        }
        startSpawn = Random.Range(minSpawn, maxSpawn);
    }

    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.transform.position, playerPrefab.transform.rotation);

    }
    private void FriesSPawner()
    {
        Instantiate(friesPrefab, FriesPos(), Quaternion.identity);
    }

    public void PlayerRespawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.transform.position, playerPrefab.transform.rotation);
    }
    public void FriesRespawner()
    {
        Instantiate(friesPrefab, FriesPos(), Quaternion.identity);
    }


    private Vector3 FriesPos()
    {
        float friesPosX = Random.Range(-17, 16);
        float friesPosY = Random.Range(-10, -7);

        Vector3 spawnPos = new Vector3(friesPosX,friesPosY,0f);

        return spawnPos;
    }
    private IEnumerator DelayNewTime()
    {
        yield return new WaitForSeconds(1f);
        PlayerRespawner();
    }
    private IEnumerator KnifeSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stopKnife)
        {
            Vector2 spawnPos = new Vector2(xPos, Random.Range(-9.5f, 0));
            Instantiate(knifePrefab,spawnPos,Quaternion.identity);
            yield return new WaitForSeconds(startSpawn);
        }
    }


}
