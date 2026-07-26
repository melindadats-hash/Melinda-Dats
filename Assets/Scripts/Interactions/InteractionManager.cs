using UnityEngine;

/// <summary>
/// Manages all interactions and event handling.
/// Centralizes interaction logic and communicates with UI.
/// </summary>
public class InteractionManager : MonoBehaviour
{
    private UIManager uiManager;
    private Interactable lastInteractedObject;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void HandleInteraction(Interactable interactable)
    {
        if (interactable == null)
            return;

        // Store reference to last interacted object
        lastInteractedObject = interactable;

        // Call the interact method on the interactable
        interactable.Interact();

        // Update UI with interaction info
        if (uiManager != null)
        {
            uiManager.ShowInteractionFeedback(
                interactable.GetInteractableName(),
                interactable.GetInteractionDescription()
            );
        }

        Debug.Log($"Interacted with: {interactable.GetInteractableName()}");
    }

    public Interactable GetLastInteractedObject()
    {
        return lastInteractedObject;
    }
}
