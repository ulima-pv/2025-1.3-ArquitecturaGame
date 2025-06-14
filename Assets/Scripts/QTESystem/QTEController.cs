using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[Serializable]
public class QTE
{
    public int id;
    public string textName;
    public KeyCode keyCode;
}

public class QTEController : MonoBehaviour
{
    public List<QTE> qteList;

    private QTE m_CurrentQTE;
    private bool m_IsQTEKeyPressed = false;
    private bool m_IsActive = false;

    void Update()
    {
        if (!m_IsActive) return;

        if (!m_IsQTEKeyPressed) return;

        foreach (KeyControl key in Keyboard.current.allKeys)
        {
            if (key != null && key.wasPressedThisFrame)
            {
                // Se presiono una tecla
                if (key.displayName.Equals(m_CurrentQTE.keyCode.ToString(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Se presiono tecla en tiempo determinado y la correcta
                    Debug.Log("Correcto");
                    break;
                }
            }
        }
    }

    public void StartQTE(int number)
    {
        m_IsQTEKeyPressed = false;
        m_IsActive = true;
        m_CurrentQTE = qteList[number];
        EventBus.Subscribe<QTEKeyEvent>(OnQTEKeyEvent);
        EventBus.Raise(new StartQTEEvent(m_CurrentQTE.textName));
    }

    public void StopQTE()
    {
        m_IsActive = false;
        EventBus.Unsubscribe<QTEKeyEvent>(OnQTEKeyEvent);
        EventBus.Raise(new StopQTEEvent());
    }

    private void OnQTEKeyEvent(QTEKeyEvent evt)
    {
        m_IsQTEKeyPressed = true;
    }
}