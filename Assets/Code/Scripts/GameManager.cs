using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager main; // Static instance for access
    private int wavesCompleted = 0; // Track the number of completed waves
    private const int totalWaves = 20; // Total waves to win
    public bool hasWon = false; // Track if the game has been won

    [Header("UI References")]
    public GameObject winPanel; // Assign in the inspector
    public GameObject losePanel; // Assign in the inspector

    

    private void Awake()
    {
        main = this; // Initialize the static instance
    }

    private void Start()
    {
        // Subscribe to the player's death event
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        // Handle lose condition
        ShowLosePanel();
    }

    public void CheckWinCondition()
    {
        if (hasWon) return; // Prevent further checks if already won

        wavesCompleted++; // Increment the wave count
        if (wavesCompleted >= totalWaves)
        {
            hasWon = true; // Set win state
            ShowWinPanel(); // Call the win panel method
        }
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
        SceneManager.LoadScene("WinScene"); // Load the win scene
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
        SceneManager.LoadScene("LoseScene"); // Load the lose scene
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}