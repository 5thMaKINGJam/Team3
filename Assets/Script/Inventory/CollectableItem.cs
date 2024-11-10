using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectableItem : MonoBehaviour
{
    public Sprite itemSprite; 

    private void OnMouseDown() 
    {
        
        InventoryManager.Instance.AddItemToSlot(itemSprite);

        
        gameObject.SetActive(false);
    }
}

