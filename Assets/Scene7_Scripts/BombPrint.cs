using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

[System.Serializable]
public class Dialogue7{
    [TextArea]
    public string dialogue; 
}
public class BombPrint : MonoBehaviour
{
   [SerializeField] private SpriteRenderer sprite_DialogueBox; 
    [SerializeField] private TextMeshProUGUI txt_Dialogue; 
    //[SerializeField] private Button dialogueButton; // Button to show/hide during transitions

 
     public void ShowSingleMessage()
    {
        
        Debug.Log("ShowSingleMessage called");
        
        sprite_DialogueBox.gameObject.SetActive(true);
        
        txt_Dialogue.gameObject.SetActive(true);
        
        txt_Dialogue.text = "꽝입니다";
        StartCoroutine(HideMessageAfterDelay(1.0f)); // Hide after 1 second

        
    }
     private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
         sprite_DialogueBox.gameObject.SetActive(false);
        
        txt_Dialogue.gameObject.SetActive(false);
        
    }

  
  
}