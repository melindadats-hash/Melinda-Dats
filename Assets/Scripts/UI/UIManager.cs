using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handles UI elements like feedback messages, dialogue, and buttons.
/// Manages all visual feedback for player interactions.
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text feedbackText;
    [SerializeField] private float feedbackDisplayDuration = 2f;
    [SerializeField] private CanvasGroup feedbackCanvasGroup;
    
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image dialoguePanel;
    [SerializeField] private Button nextDialogueButton;

    private Coroutine feedbackCoroutine;

    private void Start()
    {
        // Initialize UI elements
        if (feedbackCanvasGroup == null && feedbackText != null)
        {
            feedbackCanvasGroup = feedbackText.GetComponent<CanvasGroup>();
        }

        if (dialoguePanel != null)
        {
            dialoguePanel.gameObject.SetActive(false);
        }

        if (nextDialogueButton != null)
        {
            nextDialogueButton.onClick.AddListener(HideDialogue);
        }
    }

    /// <summary>
    /// Shows feedback text when player interacts with objects.
    /// </summary>
    public void ShowInteractionFeedback(string objectName, string description)
    {
        if (feedbackText == null)
            return;

        // Stop previous feedback coroutine if running
        if (feedbackCoroutine != null)
            StopCoroutine(feedbackCoroutine);

        feedbackText.text = $"{objectName}: {description}";
        feedbackCoroutine = StartCoroutine(FadeFeedback());
    }

    private IEnumerator FadeFeedback()
    {
        if (feedbackCanvasGroup != null)
        {
            feedbackCanvasGroup.alpha = 1f;
            yield return new WaitForSeconds(feedbackDisplayDuration);

            float fadeDuration = 0.5f;
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                feedbackCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                yield return null;
            }

            feedbackCanvasGroup.alpha = 0f;
        }
    }

    /// <summary>
    /// Shows dialogue box with text and a next button.
    /// </summary>
    public void ShowDialogue(string text)
    {
        if (dialoguePanel == null || dialogueText == null)
            return;

        dialogueText.text = text;
        dialoguePanel.gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Shows a notification or alert message.
    /// </summary>
    public void ShowNotification(string message)
    {
        Debug.Log($"Notification: {message}");
        ShowInteractionFeedback("Alert", message);
    }
}
