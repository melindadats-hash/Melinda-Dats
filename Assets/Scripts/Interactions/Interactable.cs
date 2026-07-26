using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for all interactive objects in the game.
/// Handles visual feedback and interaction callbacks.
/// </summary>
public class Interactable : MonoBehaviour
{
    [SerializeField] private string interactableName = "Object";
    [SerializeField] private string interactionDescription = "Click to interact";
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private bool playAnimation = true;
    
    [SerializeField] private UnityEvent onInteract;
    
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    private bool isHighlighted = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void OnMouseEnter()
    {
        if (spriteRenderer != null && !isHighlighted)
        {
            spriteRenderer.color = highlightColor;
            isHighlighted = true;
        }
    }

    private void OnMouseExit()
    {
        if (spriteRenderer != null && isHighlighted)
        {
            spriteRenderer.color = originalColor;
            isHighlighted = false;
        }
    }

    public void Interact()
    {
        // Play interaction animation if enabled
        if (playAnimation)
        {
            PlayInteractionAnimation();
        }

        // Trigger the interaction event
        onInteract?.Invoke();
    }

    private void PlayInteractionAnimation()
    {
        // Simple scale animation
        StartCoroutine(ScaleAnimation());
    }

    private System.Collections.IEnumerator ScaleAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.1f;
        float duration = 0.1f;
        float elapsedTime = 0f;

        // Scale up
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            yield return null;
        }

        elapsedTime = 0f;

        // Scale down
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / duration);
            yield return null;
        }

        transform.localScale = originalScale;
    }

    public string GetInteractableName() => interactableName;
    public string GetInteractionDescription() => interactionDescription;
}
