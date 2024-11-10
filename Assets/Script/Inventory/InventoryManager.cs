using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // �̱��� �������� InventoryManager�� ���� ���� �����ϰ� ����
    public Image[] itemSlots; // 4���� ItemSlot �̹����� ���� �迭

    private void Awake()
    {
        // �̱��� ���� ����: InventoryManager �ν��Ͻ��� �ϳ��� �����ϵ��� ����
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // �������� ���Կ� �߰��ϴ� �޼���
    public void AddItemToSlot(Sprite itemSprite)
    {
        // �� ������ ��ȸ�ϸ� �� ������ ã��
        foreach (var slot in itemSlots)
        {
            if (slot.sprite == null) // ������ ��� �ִ��� Ȯ��
            {
                slot.sprite = itemSprite; // ������ �̹��� �Ҵ�
                break; // ù ��° �� ���Կ��� �Ҵ��ϰ� ���� ����
            }
        }
    }
}

