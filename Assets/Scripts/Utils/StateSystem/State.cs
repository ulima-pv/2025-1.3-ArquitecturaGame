using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    protected T m_Context;

    public State(T context)
    {
        m_Context = context;
    }

    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnFinish();
}
