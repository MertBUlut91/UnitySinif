using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    private Delay delay;
    private LevelManager levelManager;
    [SerializeField] AudioClip pop;
    [SerializeField] int friesValue;
    // Start is called before the first frame update
    void Start()
    {
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        friesValue = Random.Range(1, 10);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint(friesValue);
            levelManager.count++;
            Destroy(gameObject);
            delay.FriesNewTime();
            
        }
    }
}
