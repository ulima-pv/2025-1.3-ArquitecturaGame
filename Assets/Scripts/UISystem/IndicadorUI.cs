using System;
using TMPro;
using UnityEngine;

public class IndicadorUI : MonoBehaviour
{
    private TextMeshProUGUI m_Text;

    private void Start()
    {
        EventBus.Subscribe<MovementEvent>(OnMovement);

        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void OnMovement(MovementEvent evt)
    {
        if (evt.direction.x > 0)
        {
            m_Text.text = "D";
        }
        if (evt.direction.x < 0)
        {
            m_Text.text = "A";
        }
        if (evt.direction.y > 0)
        {
            m_Text.text = "W";
        }
        if (evt.direction.y < 0)
        {
            m_Text.text = "S";
        }
    }
}
