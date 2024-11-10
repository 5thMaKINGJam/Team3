using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // InventoryUI를 참조하기 위한 변수
    [SerializeField] private InventoryUI inventoryUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 삭제
        }
    }

    void Update()
    {
        // ESC 키로 인벤토리 UI 열고 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryUI != null)
            {
                inventoryUI.ToggleInventory();
            }
            else
            {
                Debug.LogWarning("InventoryUI reference is not assigned in GameManager.");
            }
        }
    }
}
