using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public float groundRadius = 0.2f;
    public float fallCheck = 2f;
    private Rigidbody2D rb;
    private float horizontal;
    private bool isGrounded,isFalling=false;

    private bool FacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Keyboard.current.aKey.isPressed ? -1 :
                     Keyboard.current.dKey.isPressed ? 1 : 0;
        animator.SetFloat("IsRunning", Mathf.Abs(horizontal));
        if((horizontal==-1&&FacingRight==true)||(horizontal==1&&FacingRight==false))
        {
            Flip();
        }
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
        animator.SetBool("IsGrounded", isGrounded);
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isFalling = false;
            animator.SetBool("IsFalling", isFalling);
        }
        if (!isFalling && rb.linearVelocityY < fallCheck)
        {
            isFalling = true;
            animator.SetBool("IsFalling", isFalling);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    	private void Flip()
	{
		FacingRight = !FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
