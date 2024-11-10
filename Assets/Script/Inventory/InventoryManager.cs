using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Image[] itemSlots; // 4개의 ItemSlot 이미지를 담을 배열

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // itemSlots 배열이 비어있는 경우 경고 메시지 표시
        if (itemSlots == null || itemSlots.Length == 0)
        {
            Debug.LogWarning("itemSlots 배열이 비어 있습니다. Inspector에서 itemSlots에 슬롯을 할당해 주세요.");
        }
    }

    public void AddItemToSlot(Sprite itemSprite)
    {
        bool itemAdded = false; // 아이템이 추가되었는지 확인하는 변수

        foreach (var slot in itemSlots)
        {
            if (slot == null)
            {
                Debug.LogWarning("Slot is null.");
                continue; // 슬롯이 null일 경우 건너뜁니다.
            }

            Debug.Log($"Slot sprite: {slot.sprite}"); // 각 슬롯의 sprite 상태 확인

            if (slot.sprite == null) // 빈 슬롯을 찾음
            {
                slot.sprite = itemSprite; // 아이템 이미지 할당
                itemAdded = true; // 아이템이 추가됨을 표시
                break; // 첫 번째 빈 슬롯에만 할당하고 함수 종료
            }
        }

        if (!itemAdded)
        {
            Debug.LogWarning("모든 슬롯이 이미 가득 찼습니다.");
        }
    }

}
