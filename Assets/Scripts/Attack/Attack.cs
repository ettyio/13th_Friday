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
        Debug.Log("�浹 �߻�: " + collision.gameObject.name); // ������

        // Boss �±����� Ȯ��
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("�������� ����!");

            // ������ �ֱ� ���� (������ TakeDamage �Լ��� �ִٰ� ����)
            BossController boss = collision.gameObject.GetComponent<BossController>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }

        Destroy(gameObject); // �ε��� �� �ı�
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ground"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
