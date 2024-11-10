using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; 

    public void ToggleInventory()
    {
        
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    

}



