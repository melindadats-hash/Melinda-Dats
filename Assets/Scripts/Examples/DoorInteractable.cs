using UnityEngine;

/// <summary>
/// Example interactive object script.
/// Shows how to extend Interactable for custom behavior.
/// </summary>
public class DoorInteractable : Interactable
{
    [SerializeField] private bool isOpen = false;
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            
            // Play sound
            if (audioSource != null && doorOpenSound != null)
            {
                audioSource.PlayOneShot(doorOpenSound);
            }

            // Rotate door (visual feedback)
            transform.rotation = Quaternion.Euler(0, 0, -90);
            
            Debug.Log("Door opened!");
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            
            // Play sound
            if (audioSource != null && doorCloseSound != null)
            {
                audioSource.PlayOneShot(doorCloseSound);
            }

            // Reset rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            Debug.Log("Door closed!");
        }
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public bool IsOpen() => isOpen;
}
