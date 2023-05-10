using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float leftBoundry = -10;
    [SerializeField] bool isAtacking;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UIManager uiManager;
    [SerializeField] Delay delay;
    private PlayerHealth playerHealth;




    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        uiManager = GameObject.Find("UiManager").GetComponent<UIManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();

    }

    void Update()
    {
        EnemyAttack();
        EnemyDestroy();
    }
    void EnemyAttack()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0);
        
        while (!isAtacking)
        {
            SoundManager.Instance.Attack();
            isAtacking = true;
        }

    }
    void EnemyDestroy()
    {
        if (transform.position.x < leftBoundry)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            Destroy(collision.gameObject);
            SoundManager.Instance.EnemyDeath();
            delay.DelayNewTime();
            playerHealth.Lives();



        }
    }
}
