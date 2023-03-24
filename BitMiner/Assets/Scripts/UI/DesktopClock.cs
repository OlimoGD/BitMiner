using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DesktopClock : MonoBehaviour
{
    private TextMeshProUGUI clockText;

    private void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(UpdateClock), 0f, 10f);
    }

    private void UpdateClock()
    {
        clockText.text = System.DateTime.Now.ToString("HH:mm");
    }
}
