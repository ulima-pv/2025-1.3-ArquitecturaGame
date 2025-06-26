using UnityEngine;

public class FSM<T>
{
    private State<T> m_CurrentState;
    private readonly T m_Context;

    public FSM(T context)
    {
        m_Context = context;
    }

    public void Start(State<T> initialState)
    {
        m_CurrentState = initialState;
        m_CurrentState.OnStart();
    }

    public void ChangeState(State<T> newState)
    {
        m_CurrentState?.OnFinish();
        m_CurrentState = newState;
        m_CurrentState.OnStart();
    }

    public void Update()
    {
        m_CurrentState?.OnUpdate();
    }
}
