using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    public string enemyName = "Enemy";                  // Enemy �̸�
    public Slider enemyHpBar;                           // Enemy HP Bar (Slider)
    public TextMeshProUGUI battleLog;                   // Battle Log TextMeshPro
    public Button throwButton;                          // ������ ��ư
    public Button kickButton;                           // �������� ��ư
    public Button punchButton;                          // ������ ��ư

    public GameObject throwEffectPrefab;                // ������ ȿ�� ������ (Hit_01)
    public GameObject kickEffectPrefab;                 // �������� ȿ�� ������ (Hit_02)
    public GameObject punchEffectPrefab;                // ������ ȿ�� ������ (Hit_04)
    public Transform enemyPosition;                     // Enemy�� ��ġ�� ��Ÿ���� Transform

    private int enemyMaxHp = 100;                       // Enemy�� �ִ� HP
    private int enemyCurrentHp;

    void Start()
    {
        enemyCurrentHp = enemyMaxHp;
        enemyHpBar.maxValue = enemyMaxHp;
        enemyHpBar.value = enemyCurrentHp;

        throwButton.onClick.AddListener(() => Attack("������", throwEffectPrefab));
        kickButton.onClick.AddListener(() => Attack("��������", kickEffectPrefab));
        punchButton.onClick.AddListener(() => Attack("������", punchEffectPrefab));
    }

    // ���� �޼ҵ�
    void Attack(string attackType, GameObject effectPrefab)
    {
        int damage = CalculateDamage(attackType);
        bool isSuccessful = Random.Range(0, 100) < 75; // ���� ���� Ȯ�� 75%

        if (isSuccessful)
        {
            enemyCurrentHp -= damage;
            enemyCurrentHp = Mathf.Clamp(enemyCurrentHp, 0, enemyMaxHp); // HP 0 ���Ϸ� ���� �ʰ� ����
            enemyHpBar.value = enemyCurrentHp;
            battleLog.text = $"{attackType} ���� ����!\n {enemyName}���� {damage} ���ظ� �������ϴ�.";
            PlayEffect(effectPrefab); // ȿ�� ����
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

    // ȿ�� ��� �޼ҵ�
    void PlayEffect(GameObject effectPrefab)
    {
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab, enemyPosition.position, Quaternion.identity);
            Destroy(effect, 1.5f); // 1.5�� �Ŀ� ȿ�� �ı� (�ʿ信 ���� ���� ����)
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
