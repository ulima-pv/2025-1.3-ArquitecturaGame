using System;
using UnityEngine;

public class IdleState : State<PlayerContext>
{
    public IdleState(PlayerContext context) : base(context)
    {
    }

    public override void OnStart()
    {
        Debug.Log("Se inicializa el estado Idle");
        EventBus.Subscribe<MovementEvent>(OnMovement);
        m_Context.Direction = Vector2.zero;
    }

    private void OnMovement(MovementEvent evt)
    {
        m_Context.Direction = evt.direction;
    }

    public override void OnUpdate()
    {
        if (m_Context.Direction.magnitude != 0f)
        {
            m_Context.FSM.ChangeState(m_Context.walkState);
        }
    }

    public override void OnFinish()
    {
        Debug.Log("Se sale del estado Idle");
        EventBus.Unsubscribe<MovementEvent>(OnMovement);
    }
}
