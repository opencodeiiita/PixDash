using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    public float punchCooldown = 0.5f;
    public int debugDamageAmount = 10;

    private Animator animator;
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private float horizontal;
    private bool isGrounded;
    private bool FacingRight = true;
    private float lastPunchTime = -999f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.onDeath.AddListener(OnPlayerDeath);
        }
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.isDead)
        {
            return;
        }

        horizontal = Keyboard.current.aKey.isPressed ? -1 :
                     Keyboard.current.dKey.isPressed ? 1 : 0;

        if ((horizontal == -1 && FacingRight == true) || (horizontal == 1 && FacingRight == false))
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryPunch();
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            DebugTakeDamage();
        }

        float speed = Mathf.Abs(horizontal * moveSpeed);
        animator.SetFloat("Horizontal Speed", speed);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Vertical Speed", rb.linearVelocity.y);
    }

    private void FixedUpdate()
    {
        if (playerHealth != null && playerHealth.isDead) return;
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    private void TryPunch()
    {
        if (Time.time < lastPunchTime + punchCooldown) return;

        lastPunchTime = Time.time;
        animator.SetTrigger("Punch");
    }

    private void OnPlayerDeath()
    {
        animator.SetTrigger("Death");
        rb.linearVelocity = Vector2.zero;
    }

    private void DebugTakeDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(debugDamageAmount);
            Debug.Log($"Debug damage: {debugDamageAmount}. Health: {playerHealth.currentHealth}");
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
