using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCharacter : MonoBehaviour
{
    public string characterName = "Enemy"; // �� ĳ������ �̸�
    public int maxHealth = 100;
    public int currentHealth;
    public Slider enemyHPBar;            // HP �� UI�� ����
    public TMP_Text battleLog;           // ���� �α׸� ǥ���� TextMeshPro �ؽ�Ʈ ������Ʈ

    private void Start()
    {
        currentHealth = maxHealth;

        if (enemyHPBar != null)
        {
            enemyHPBar.maxValue = maxHealth;
            enemyHPBar.value = currentHealth;
        }
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called with damage: " + damage);
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        if (currentHealth == 0 && battleLog != null)
        {
            battleLog.text += $"\n{characterName}��(��) �й��߽��ϴ�!";
        }
    }

    private void UpdateHealthUI()
    {
        if (enemyHPBar != null)
        {
            enemyHPBar.value = currentHealth;
        }
        else
        {
            Debug.LogError("Enemy HP Bar is not assigned in the Inspector.");
        }
    }
}
