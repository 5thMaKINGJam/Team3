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

       
    }

    // ���� �޼ҵ�
    

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
    
}
