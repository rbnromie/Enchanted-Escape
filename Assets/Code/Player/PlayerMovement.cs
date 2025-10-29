using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Rigidbody2D platform;
   
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public Animator anim;
               
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }

        if (horizontal >= 0.1f || horizontal<= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else 
        { 
            anim.SetBool("isRunning", false);
        }


        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        } 

        Flip();
    }


    private void FixedUpdate()
    {
        float accelRate = 1f;
        float targetSpeed = speed;

        if (platform)
        {
            rb.linearVelocity = new Vector2(horizontal * targetSpeed * accelRate, rb.linearVelocity.y) + platform.linearVelocity * Vector2.right;
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal * targetSpeed * accelRate, rb.linearVelocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Floor"))
        {
            transform.parent = collision.transform;
            platform = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 10;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            transform.parent = null;
            platform = null;
            rb.gravityScale = 2.8f;
        }

      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor" ))
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            anim.SetBool("isJumping", true);
        }
    } 

    
}
