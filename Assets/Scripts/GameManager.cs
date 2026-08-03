using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the overall game state and scene logic.
/// Handles initialization and game flow.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string gameTitle = "Point-and-Click Adventure";
    [SerializeField] private bool debugMode = true;

    private PlayerController playerController;
    private InteractionManager interactionManager;
    private UIManager uiManager;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Don't destroy this object when loading new scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Find all required managers
        playerController = FindObjectOfType<PlayerController>();
        interactionManager = FindObjectOfType<InteractionManager>();
        uiManager = FindObjectOfType<UIManager>();

        if (debugMode)
        {
            Debug.Log($"Game Started: {gameTitle}");
            Debug.Log($"PlayerController: {(playerController != null ? "Found" : "Missing")}");
            Debug.Log($"InteractionManager: {(interactionManager != null ? "Found" : "Missing")}");
            Debug.Log($"UIManager: {(uiManager != null ? "Found" : "Missing")}");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
