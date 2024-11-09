using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public string enemyName = "Enemy";      // Enemy �̸�
    public Slider enemyHpBar;               // Enemy HP Bar (Slider)
    public TextMeshProUGUI battleLog;       // Battle Log TextMeshPro
    public Button throwButton;              // ������ ��ư
    public Button kickButton;               // �������� ��ư
    public Button punchButton;              // ������ ��ư

    private int enemyMaxHp = 100;           // Enemy�� �ִ� HP
    private int enemyCurrentHp;

    void Start()
    {
        enemyCurrentHp = enemyMaxHp;
        enemyHpBar.maxValue = enemyMaxHp;
        enemyHpBar.value = enemyCurrentHp;

        throwButton.onClick.AddListener(() => Attack("������"));
        kickButton.onClick.AddListener(() => Attack("��������"));
        punchButton.onClick.AddListener(() => Attack("������"));
    }

    // ���� �޼ҵ�
    void Attack(string attackType)
    {
        int damage = CalculateDamage(attackType);
        bool isSuccessful = Random.Range(0, 100) < 75; // ���� ���� Ȯ�� 75%

        if (isSuccessful)
        {
            enemyCurrentHp -= damage;
            enemyCurrentHp = Mathf.Clamp(enemyCurrentHp, 0, enemyMaxHp); // HP 0 ���Ϸ� ���� �ʰ� ����
            enemyHpBar.value = enemyCurrentHp;
            battleLog.text = $"{attackType} ���� ����!\n {enemyName}���� {damage} ���ظ� �������ϴ�.";
        }
        else
        {
            battleLog.text = $"{attackType} ���� ����!\n {enemyName}���� ���ظ� ������ ���߽��ϴ�.";
        }

        // Enemy�� HP�� 0�� �Ǹ� ���� �¸� �޽��� ǥ��
        if (enemyCurrentHp <= 0)
        {
            battleLog.text = $"{enemyName}�� óġ�߽��ϴ�!";
            throwButton.interactable = false;
            kickButton.interactable = false;
            punchButton.interactable = false;
        }
    }

    // ���� ������ ���� ���� ���
    int CalculateDamage(string attackType)
    {
        int damage = 0;
        switch (attackType)
        {
            case "������":
                damage = Random.Range(5, 15); // ������: 5~15 ����
                break;
            case "��������":
                damage = Random.Range(10, 20); // ��������: 10~20 ����
                break;
            case "������":
                damage = Random.Range(15, 25); // ������: 15~25 ����
                break;
        }
        return damage;
    }
}

