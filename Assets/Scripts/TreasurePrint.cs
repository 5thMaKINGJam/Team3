using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

[System.Serializable]
public class Dialogue8{
    [TextArea]
    public string dialogue; 
}
public class TreasurePrint : MonoBehaviour
{
   [SerializeField] private SpriteRenderer sprite_DialogueBox; 
    [SerializeField] private TextMeshProUGUI txt_Dialogue; 
    public GameObject treasureImage; // Image to display on collision
    private bool isTreasureImageVisible = false;
    [SerializeField] private Sprite itemSprite;

   
       void Update()
    {
        // Check for space key press to hide the image
       if (isTreasureImageVisible && Input.GetKeyDown(KeyCode.Space))
        {
            treasureImage.SetActive(false);
            isTreasureImageVisible = false;
        }
    }
 
     public void ShowSingleMessage()
    {
        Debug.Log("ShowSingleMessage called");
        treasureImage.gameObject.SetActive(true);
        isTreasureImageVisible = true;

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItemToSlot(itemSprite);
            Debug.Log("Item added to inventory: " + itemSprite.name);
        }
        else
        {
            Debug.LogError("InventoryManager instance not found!");
        }

       
         
    }
     
    
  
}