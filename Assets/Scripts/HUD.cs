using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keys;
    public void UpdateText(int number)
    {
        keys.text = "Keys: " + number;
    }
}
