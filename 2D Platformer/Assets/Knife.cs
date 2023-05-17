using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] ParticleSystem knifeParticle;
    private float destroyLimit;
    private Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < -destroyLimit)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(1);
            Instantiate(knifeParticle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Movement.Cancel();
            Destroy(gameObject);
            PlayerHealth.Instance.Lives();
            Delay.Instance.DelayNewTime();


        }
    }
}
