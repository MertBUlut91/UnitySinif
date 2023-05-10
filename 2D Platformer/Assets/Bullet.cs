using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private Delay delay;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem playerDeathParticle;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(playerDeathParticle, transform.position, Quaternion.identity);
            playerHealth.Lives();
            delay.DelayNewTime();
            Movement.Cancel();
        }
        if (collision.gameObject.CompareTag("Zemin"))
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);
        }
    }
}
