using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue3
{
    [TextArea]
    public string dialogue;
}

public class Test4 : MonoBehaviour
{
    [SerializeField] private Image sprite_DialogueBox;
    [SerializeField] private TextMeshProUGUI txt_Dialogue;
    [SerializeField] private Image fadeImage; // UI Image for fade effect
    [SerializeField] private float fadeDuration = 1.0f; // Duration of the fade effect
    [SerializeField] private int nextSceneIndex; // Index of the next scene to load
    [SerializeField] private Image[] imagesToShow; // Images to display sequentially
    [SerializeField] private float imageDisplayDuration = 2.0f; // Duration each image is displayed
    [SerializeField] private GameObject creditsPanel; // Panel to display credits
    [SerializeField] private Button dialogueButton; // Button to show/hide during transitions

    private bool isDialogue = false;
    private int count = 0;
    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialogue()
    {
        Onoff(true);
        count = 0;
        NextDialogue();
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        count++;
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

        // Ensure all images are initially inactive
        foreach (var image in imagesToShow)
        {
            image.gameObject.SetActive(false);
        }

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
                    StartCoroutine(ShowImagesSequentially()); // Show images after dialogue ends
                }
            }
        }
    }

    private IEnumerator ShowImagesSequentially()
    {
        // Turn off dialogue button when images start to show
        if (dialogueButton != null)
        {
            dialogueButton.gameObject.SetActive(false);
        }

        foreach (var image in imagesToShow)
        {
            image.gameObject.SetActive(true);
            yield return new WaitForSeconds(imageDisplayDuration);
            image.gameObject.SetActive(false);
        }

        StartCoroutine(ShowCreditsAndFadeOut()); // Start showing credits and fade out after images
    }

    private IEnumerator ShowCreditsAndFadeOut()
    {
        // Activate credits panel
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }

        yield return new WaitForSeconds(3.0f); // Wait for a few seconds to show the credits

        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, timer / fadeDuration);
            yield return null;
        }

        Application.Quit(); // Exit the game after fade out
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
