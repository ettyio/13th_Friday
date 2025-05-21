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
            rb.linearVelocity = throwPoint.forward * throwForce;
        }
    }
}
