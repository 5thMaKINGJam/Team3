using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // �κ��丮 �г��� ������ ����

    public void ToggleInventory()
    {
        // �κ��丮 �г��� Ȱ��ȭ ���¸� ����մϴ�.
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}



