using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float radius;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;
    [SerializeField] private float horizontalMove;

    [SerializeField] Transform feetPos;

    [SerializeField] LevelManager levelManager;
    [SerializeField] Delay delay;


    [SerializeField] SpriteRenderer playerRenderer;

    [SerializeField] LayerMask layerMask;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        PlayerRendererTurn();
        PlayerGravity();

        if (!LevelManager.canMove)
        {
            PlayerMove();
            PlayerJump();
        }

        PlayerDeath();


    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    void PlayerRendererTurn()
    {
        if (horizontalMove > 0)
        {
            playerRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            playerRenderer.flipX = true;
        }
    }
    void PlayerDeath()
    {
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
            SoundManager.Instance.FallDeath();
            delay.DelayNewTime();
        }
    }
    void PlayerGravity()
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
    void PlayerMove()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            SoundManager.Instance.Jump();
        }
    }
}   
