using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPos;
    [SerializeField] float enemySpeed;

    [SerializeField] GameObject enemy;
    [SerializeField] bool moveEnemy;


    private void Start()
    {
    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveEnemy = true;
        }
    }

    void MoveEnemy()
    {
        if (moveEnemy)
        {
            for (int i = 0; i < 1; i++)
            {
                SpawnEnemy();
                moveEnemy = false;
            }
            //enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 10, 0 );
            
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPos.transform.position, enemyPrefab.transform.rotation);
    }
}
