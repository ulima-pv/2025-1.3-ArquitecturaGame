using System;
using UnityEngine;

public class WalkState : State<PlayerContext>
{
    public WalkState(PlayerContext context) : base(context)
    {
    }

    public override void OnStart()
    {
        Debug.Log("Se inicializa el estado Walk");
        EventBus.Subscribe<MovementEvent>(OnMovement);
    }

    private void OnMovement(MovementEvent evt)
    {
        m_Context.Direction = evt.direction;
    }

    public override void OnUpdate()
    {
        m_Context.transform.position += new Vector3(
            m_Context.Direction.x * Time.deltaTime * m_Context.Speed,
            0f,
            m_Context.Direction.y * Time.deltaTime * m_Context.Speed);

        if (m_Context.Direction == Vector2.zero)
        {
            // Regresamos al estado idle
            m_Context.FSM.ChangeState(m_Context.idleState);
        }
    }

    public override void OnFinish()
    {
        Debug.Log("Se sale del estado Walk");
        EventBus.Unsubscribe<MovementEvent>(OnMovement);
    }

}
