using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    public string enemyName = "Enemy";                  // Enemy 이름
    public Slider enemyHpBar;                           // Enemy HP Bar (Slider)
    public TextMeshProUGUI battleLog;                   // Battle Log TextMeshPro
    public Button throwButton;                          // 던지기 버튼
    public Button kickButton;                           // 날아차기 버튼
    public Button punchButton;                          // 때리기 버튼

    public GameObject throwEffectPrefab;                // 던지기 효과 프리팹 (Hit_01)
    public GameObject kickEffectPrefab;                 // 날아차기 효과 프리팹 (Hit_02)
    public GameObject punchEffectPrefab;                // 때리기 효과 프리팹 (Hit_04)
    public Transform enemyPosition;                     // Enemy의 위치를 나타내는 Transform

    private int enemyMaxHp = 100;                       // Enemy의 최대 HP
    private int enemyCurrentHp;

    void Start()
    {
        enemyCurrentHp = enemyMaxHp;
        enemyHpBar.maxValue = enemyMaxHp;
        enemyHpBar.value = enemyCurrentHp;

        throwButton.onClick.AddListener(() => Attack("던지기", throwEffectPrefab));
        kickButton.onClick.AddListener(() => Attack("날아차기", kickEffectPrefab));
        punchButton.onClick.AddListener(() => Attack("때리기", punchEffectPrefab));
    }

    // 공격 메소드
    void Attack(string attackType, GameObject effectPrefab)
    {
        int damage = CalculateDamage(attackType);
        bool isSuccessful = Random.Range(0, 100) < 75; // 공격 성공 확률 75%

        if (isSuccessful)
        {
            enemyCurrentHp -= damage;
            enemyCurrentHp = Mathf.Clamp(enemyCurrentHp, 0, enemyMaxHp); // HP 0 이하로 가지 않게 제한
            enemyHpBar.value = enemyCurrentHp;
            battleLog.text = $"{attackType} 공격 성공!\n {enemyName}에게 {damage} 피해를 입혔습니다.";
            PlayEffect(effectPrefab); // 효과 실행
        }
        else
        {
            battleLog.text = $"{attackType} 공격 실패!\n {enemyName}에게 피해를 입히지 못했습니다.";
        }

        // Enemy의 HP가 0이 되면 게임 승리 메시지 표시
        if (enemyCurrentHp <= 0)
        {
            battleLog.text = $"{enemyName}를 처치했습니다!";
            throwButton.interactable = false;
            kickButton.interactable = false;
            punchButton.interactable = false;
        }
    }

    // 효과 재생 메소드
    void PlayEffect(GameObject effectPrefab)
    {
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab, enemyPosition.position, Quaternion.identity);
            Destroy(effect, 1.5f); // 1.5초 후에 효과 파괴 (필요에 따라 조정 가능)
        }
    }

    // 공격 종류에 따른 피해 계산
    int CalculateDamage(string attackType)
    {
        int damage = 0;
        switch (attackType)
        {
            case "던지기":
                damage = Random.Range(5, 15); // 던지기: 5~15 피해
                break;
            case "날아차기":
                damage = Random.Range(10, 20); // 날아차기: 10~20 피해
                break;
            case "때리기":
                damage = Random.Range(15, 25); // 때리기: 15~25 피해
                break;
        }
        return damage;
    }
}
