using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public GameObject[] itemSlots; // 4���� ������ ���� �迭

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItemToSlot(Sprite itemSprite)
    {
        foreach (var slot in itemSlots)
        {
            Image slotImage = slot.GetComponentInChildren<Image>();
            if (slotImage.sprite == null) // ������ ����ִ��� Ȯ��
            {
                slotImage.sprite = itemSprite; // ������ �̹��� �Ҵ�
                break;
            }
        }
    }
}

