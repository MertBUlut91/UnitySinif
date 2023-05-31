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
    [Header("Mode Speed")]
    [SerializeField] float easyMoveSpeed;
    [SerializeField] float normalMoveSpeed;
    [SerializeField] float hardMoveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HardenedLevel();
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

    private void OnTriggerEnter2D(Collider2D collision)
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

    private void HardenedLevel()
    {
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            moveSpeed = easyMoveSpeed;
        }
        if (PlayerPrefs.HasKey("Normal Mode"))
        {
            moveSpeed = normalMoveSpeed;
        }
        if (PlayerPrefs.HasKey("Hard Mode"))
        {
            moveSpeed = hardMoveSpeed;
        }
    }
}
