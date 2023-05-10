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

    public static bool canDash = true;
    public static bool isDashing;
    public static bool dashed;
    [SerializeField] float dashAmount = 20;
    [SerializeField] float dashTime = 0.3f;
    public static float dashCooldown = 2.5f;

    [SerializeField] Transform feetPos;

    [SerializeField] LevelManager levelManager;
    [SerializeField] Delay delay;


    [SerializeField] SpriteRenderer playerRenderer;

    [SerializeField] LayerMask layerMask;
    private Rigidbody2D rb;
    private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        playerRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
        }
        if (!LevelManager.canMove)
        {
            PlayerMove();
            PlayerJump();
        }

        PlayerRendererTurn();
        PlayerGravity();
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
            Cancel();
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
        if (isDashing)
        {
            return;
        }
        horizontalMove = Input.GetAxis("Horizontal");
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

    IEnumerator Dash()
    {
        Debug.Log("Dashing");
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0;
        fallGravityScale = 0;
        rb.velocity = new Vector2(horizontalMove * dashAmount, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1;
        fallGravityScale = 5;
        isDashing = false;
        dashed = true;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        Debug.Log("Can Dash");
        canDash = true;
    }
    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
    }
}
