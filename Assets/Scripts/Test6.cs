using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue6
{
    [TextArea]
    public string dialogue;
}

public class Test6 : MonoBehaviour
{
    [SerializeField] private Image sprite_DialogueBox;
    [SerializeField] private TextMeshProUGUI txt_Dialogue;
    [SerializeField] private Image fadeImage; // UI Image for fade effect
    [SerializeField] private float fadeDuration = 1.0f; // Duration of the fade effect
    [SerializeField] private int nextSceneIndex; // Index of the next scene to load
    [SerializeField] private Button dialogueButton; // Button to show/hide during transitions
    [SerializeField] private GameObject creditsPanel; // Panel to display credits

    private bool isDialogue = false;
    private int count = 0;
    [SerializeField] private Dialogue6[] dialogue;

    public void ShowDialogue()
    {
        Debug.Log("ShowDialogue called");
        Onoff(true);
        count = 0;
        NextDialogue();
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;

        // Check if the specific dialogue needs to shake
        if (count == 1) // Apply shake only to the second dialogue
        {
            StartCoroutine(ShakeText());
        }

        count++;
    }

    private IEnumerator ShakeText()
    {
        Vector3 originalPosition = txt_Dialogue.rectTransform.localPosition;
        float duration = 1.5f; // Duration of the shake
        float elapsed = 0f;
        float magnitude = 5f; // Shake intensity

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-magnitude, magnitude);
            float offsetY = Random.Range(-magnitude, magnitude);
            txt_Dialogue.rectTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        txt_Dialogue.rectTransform.localPosition = originalPosition; // Reset position
    }

    private void Onoff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void Start()
    {
        Onoff(false);
        fadeImage.color = new Color(0, 0, 0, 0); // Ensure fade image is transparent at start

        // Ensure credits panel is initially inactive
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                {
                    Onoff(false);
                    StartCoroutine(FadeOutAndShowCredits()); // Start fade out and show credits
                }
            }
        }
    }

    private IEnumerator FadeOutAndShowCredits()
    {
        // Turn off dialogue button when images start to show
        if (dialogueButton != null)
        {
            dialogueButton.gameObject.SetActive(false);
        }

        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, timer / fadeDuration);
            yield return null;
        }

        // Show the credits panel after the fade out is complete
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }

        // Wait for a few seconds to show the credits before exiting the game
        yield return new WaitForSeconds(5.0f); // Adjust the duration as needed
        Application.Quit(); // Exit the game
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
