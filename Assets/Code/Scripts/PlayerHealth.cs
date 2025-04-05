using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public delegate void OnPlayerDeath();
    public event OnPlayerDeath PlayerDied;

    private void Start()
    {
        ResetPlayerHealth();
    }

    public void ResetPlayerHealth() 
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        PlayerDied?.Invoke(); // Notify GameManager of player death
        GameManager.main.ShowLosePanel(); // Call the lose panel method
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
