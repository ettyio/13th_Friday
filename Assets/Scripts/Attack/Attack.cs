using UnityEngine;

public class Attack : MonoBehaviour
{
    public float lifeTime = 3f;
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌 발생: " + collision.gameObject.name); // 디버깅용

        // Boss 태그인지 확인
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("보스에게 명중!");

            // 데미지 주기 예시 (보스에 TakeDamage 함수가 있다고 가정)
            BossController boss = collision.gameObject.GetComponent<BossController>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }

        Destroy(gameObject); // 부딪힌 후 파괴
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ground"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
