using UnityEngine;
using UnityEngine.EventSystems;

public class CollectableItem : MonoBehaviour, IPointerClickHandler
{
    public Sprite itemSprite; // �� �������� ��������Ʈ (������ �̹���)

    public void OnPointerClick(PointerEventData eventData)
    {
        // InventoryManager�� AddItemToSlot �޼��带 ȣ���Ͽ� �������� �κ��丮�� �߰�
        InventoryManager.Instance.AddItemToSlot(itemSprite);

        // �������� ȹ���� �� ��������� ��Ȱ��ȭ (�Ǵ� ����)
        gameObject.SetActive(false);
    }
}

