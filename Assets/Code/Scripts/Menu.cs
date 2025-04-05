using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyGUI;
    [SerializeField] TextMeshProUGUI HealthGUI;

    public PlayerHealth playerHealth;
    private void OnGUI()
    {
        currencyGUI.text = "$" + levelmanager.main.currency.ToString();
        HealthGUI.text = playerHealth.GetCurrentHealth().ToString();
    }

    public void SetSelected() { 

    }
}
