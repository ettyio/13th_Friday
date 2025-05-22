using UnityEngine;

public class Projecttile : MonoBehaviour
{
    public float lifeTime = 3f;
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
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
}
