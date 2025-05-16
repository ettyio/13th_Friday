using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public int maxHit = 5;
    private int currentHit = 0;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        TryJump();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    void TryJump()
    {
        if (isGrounded && Random.Range(0f, 1f) < 0.01f)  // 1% 확률로 점프
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void HitFromAbove()
    {
        currentHit++;
        if (currentHit >= maxHit)
        {
            Destroy(gameObject); // 보스 사망
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            // 위에서 부딪힘 = 마리오가 밟음
            HitFromAbove();
        }
        else
        {
            isGrounded = true;
        }
    }
}