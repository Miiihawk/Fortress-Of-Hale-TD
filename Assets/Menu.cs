using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyGUI;

    private void OnGUI()
    {
        currencyGUI.text = "$" + levelmanager.main.currency.ToString();
    }
}
