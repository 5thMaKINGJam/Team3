using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; 
    public Image[] itemSlots; 

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
            if (slot.sprite == null)
            {
                slot.sprite = itemSprite; 
                break; 
            }
        }
    }
}

