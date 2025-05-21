using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int maxHit = 5;
    private int currentHit = 0;
    private float lastHitTime = 0f;       // 마지막 피격 시간
    public float hitCooldown = 0.5f;      // 피격 쿨타임 0.5초

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = GetComponent<Collider2D>().bounds.center;

            if (contactPoint.y > center.y + 0.5f)
            {
                if (Time.time - lastHitTime >= hitCooldown)
                {
                    lastHitTime = Time.time; // 마지막 피격 시간 업데이트

                    currentHit++;
                    Debug.Log("보스 밟힘! 현재 피격 횟수: " + currentHit);

                    if (currentHit >= maxHit)
                    {
                        Debug.Log("보스 사망!");
                        Destroy(gameObject);
                    }

                    // 플레이어 반동 점프
                    Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 10f);
                    }
                }
            }
            else
            {
                Debug.Log("보스가 플레이어 공격!");
                collision.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}