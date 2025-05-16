using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool movingRight = true;

    public float jumpForce = 7f;
    private bool isGrounded = true;

    public float jumpCooldown = 2f;
    private float jumpTimer = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float xSpeed = movingRight ? moveSpeed : -moveSpeed;
        rb.linearVelocity = new Vector2(xSpeed, rb.linearVelocity.y);

        
        jumpTimer += Time.deltaTime;

        
        if (isGrounded && jumpTimer >= jumpCooldown && Random.value < 0.1f)
        {
            Jump();
            jumpTimer = 0f;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }

        
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}