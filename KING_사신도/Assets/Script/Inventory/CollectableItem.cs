using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public Sprite itemSprite; // �� �������� ��������Ʈ (������ �̹���)

    private void OnMouseDown() // �������� Ŭ������ �� ȣ�� (PC ȯ�濡�� ��� ����)
    {
        // InventoryManager�� AddItemToSlot �޼��带 ȣ���Ͽ� �������� �κ��丮�� �߰�
        InventoryManager.Instance.AddItemToSlot(itemSprite);

        // �������� ȹ���� �� ��������� ��Ȱ��ȭ (�Ǵ� ����)
        gameObject.SetActive(false);
    }
}
