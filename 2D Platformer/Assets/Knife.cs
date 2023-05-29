using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] ParticleSystem knifeParticle;
    [SerializeField] float destroyLimit;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.x < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
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
