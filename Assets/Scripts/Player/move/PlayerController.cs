using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    private bool facingRight = true;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    public Transform groundCheck; // 바닥 체크를 위한 위치
    public float groundCheckRadius = 0.2f; // 바닥 체크 범위
    public LayerMask groundLayer; // 바닥 레이어

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log($"isGrounded: {isGrounded}, Velocity.y: {rb.linearVelocity.y}");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump key pressed");
        }

        float moveX = 0f;

        // 좌우 이동
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            if (!facingRight) Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            if (facingRight) Flip();
        }

        // 이동 적용
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // 점프 (스페이스바) — 바닥에 있을 때만
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;  // 점프하면 바로 false로
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // 바닥 체크를 위해서 GroundCheck 사용
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // 바닥에 닿았는지 감지
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 감지됨: " + collision.gameObject.name);
    }
}
