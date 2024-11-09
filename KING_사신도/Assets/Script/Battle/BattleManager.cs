using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public EnemyCharacter enemy;       // �� ĳ���͸� ����
    public TMP_Text battleLog;         // ���� �α׸� ǥ���� TextMeshPro �ؽ�Ʈ ������Ʈ

    // ���ݷ� �� ���� Ȯ�� ����
    public int basicAttackPower = 10;
    public int strongAttackPower = 15;
    public int specialAttackPower = 20;
    public float basicAttackChance = 0.9f;
    public float strongAttackChance = 0.7f;
    public float specialAttackChance = 0.5f;

    private void Start()
    {
        // �ʼ� ������ �ùٸ��� �����Ǿ����� Ȯ��
        if (enemy == null)
        {
            Debug.LogError("Enemy reference is missing in BattleManager.");
        }
        if (battleLog == null)
        {
            Debug.LogError("Battle Log reference is missing in BattleManager.");
        }
    }

    public void OnBasicAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Basic Attack button clicked.");

        if (Random.value < basicAttackChance)
        {
            int damage = Random.Range(basicAttackPower - 5, basicAttackPower + 5);
            enemy.TakeDamage(damage);
            battleLog.text = $"�⺻ ���� ����! {enemy.characterName}���� {damage}�� �������� �������ϴ�.";
        }
        else
        {
            battleLog.text = "�⺻ ������ �����߽��ϴ�!";
        }
    }

    public void OnStrongAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Strong Attack button clicked.");

        if (Random.value < strongAttackChance)
        {
            int damage = Random.Range(strongAttackPower - 10, strongAttackPower + 10);
            enemy.TakeDamage(damage);
            battleLog.text = $"������ ���� ����! {enemy.characterName}���� {damage}�� �������� �������ϴ�.";
        }
        else
        {
            battleLog.text = "������ ������ �����߽��ϴ�!";
        }
    }

    public void OnSpecialAttack()
    {
        if (enemy == null || battleLog == null) return;

        Debug.Log("Special Attack button clicked.");

        if (Random.value < specialAttackChance)
        {
            int damage = Random.Range(specialAttackPower - 15, specialAttackPower + 15);
            enemy.TakeDamage(damage);
            battleLog.text = $"Ư�� ���� ����! {enemy.characterName}���� {damage}�� �������� �������ϴ�.";
        }
        else
        {
            battleLog.text = "Ư�� ������ �����߽��ϴ�!";
        }
    }
}

