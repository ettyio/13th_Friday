using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject projectilePrefab;     // 던질 투사체 프리팹
    public Transform throwPoint;            // 투사체가 나갈 위치
    public float throwForce = 20f;          // 던지는 힘

    void Update()
    {
        // V 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.V))
        {
            ThrowProjectile();
        }
    }

    void ThrowProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

            // 충돌 감지 모드 설정
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            // 중력 영향 확인
            rb.useGravity = true;
        }
    }
}
