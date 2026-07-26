using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles player input and raycasting for detecting clicked objects.
/// Supports both mouse and touch input for mobile compatibility.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float raycastDistance = 100f;
    
    private InteractionManager interactionManager;
    private bool isPointerOverUI = false;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        
        interactionManager = FindObjectOfType<InteractionManager>();
    }

    private void Update()
    {
        // Check for mouse click (Editor/PC)
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }

        // Check for touch input (Mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleInput(touch.position);
            }
        }
    }

    private void HandleInput(Vector3 inputPosition)
    {
        // Check if pointer is over UI
        if (EventSystem.current.IsPointerOverGameObject(-1))
            return;

        Ray ray = mainCamera.ScreenPointToRay(inputPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance);

        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactionManager.HandleInteraction(interactable);
            }
        }
    }
}
