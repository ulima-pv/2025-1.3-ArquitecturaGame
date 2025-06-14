using System;
using TMPro;
using UnityEngine;

public class QTEMessageUI : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    void Start()
    {
        EventBus.Subscribe<StartQTEEvent>(OnStartQTEEvent);
        EventBus.Subscribe<StopQTEEvent>(OnStopQTEEvent);
    }

    private void OnStartQTEEvent(StartQTEEvent evt)
    {
        gameObject.SetActive(true);
        m_Text.text = evt.message;
    }
    private void OnStopQTEEvent(StopQTEEvent evt)
    {
        m_Text.text = "";
        gameObject.SetActive(false);
    }

}
