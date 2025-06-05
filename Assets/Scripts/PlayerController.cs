using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 4f;
    private Vector2 m_Direction = Vector2.zero;

    private void Start()
    {
        EventBus.Subscribe<MovementEvent>(OnMovement);
    }

    private void OnMovement(MovementEvent evt)
    {
        m_Direction = evt.direction;
    }

    void Update()
    {
        transform.position += new Vector3(
            m_Direction.x * Time.deltaTime * Speed,
            0f,
            m_Direction.y * Time.deltaTime * Speed);
    }
}
