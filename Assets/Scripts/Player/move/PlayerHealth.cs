using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // UI ����� ���� �߰�
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

    public Slider healthSlider; // ����Ƽ���� ����
    public Text hpText;

    private float invincibleTime = 1.0f;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthSlider.value = currentHealth;

        StartCoroutine(Invincibility());
        StartCoroutine(BlinkRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthSlider.value = currentHealth;
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = currentHealth + " / " + maxHealth;
        }
    }

    void Die()
    {
        if (isDead) return;

        SceneManager.LoadScene("gameover"); // GameOver ������ ��ȯ
        isDead = true;
        Debug.Log("�÷��̾� ���");
        // TODO: ���� ���� ó��
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    IEnumerator BlinkRed()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    void Update()
    {
        // Ű�� ������ �׽�Ʈ�� ü�� ���
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(40); // �����̽��� ������ 40��ŭ ������
        }
    }
}
