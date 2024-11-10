using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectableItem : MonoBehaviour
{
    public Sprite itemSprite; // �� �������� ��������Ʈ (������ �̹���)

    private void OnMouseDown() // Collider 2D�� �ִ� ������Ʈ�� Ŭ���� �� ȣ���
    {
        // InventoryManager�� AddItemToSlot �޼��带 ȣ���Ͽ� �������� �κ��丮�� �߰�
        InventoryManager.Instance.AddItemToSlot(itemSprite);

        // �������� ȹ���� �� ��������� ��Ȱ��ȭ (�Ǵ� ����)
        gameObject.SetActive(false);
    }
}

