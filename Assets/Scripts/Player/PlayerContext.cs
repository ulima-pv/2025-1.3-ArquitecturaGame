using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    public FSM<PlayerContext> FSM;
    public float Speed = 4f;
    public Vector2 Direction = Vector2.zero;

    public IdleState idleState;
    public WalkState walkState;
    void Awake()
    {
        idleState = new IdleState(this);
        walkState = new WalkState(this);
    }

    void Start()
    {
        FSM = new FSM<PlayerContext>(this);
        FSM.Start(idleState); // Estado inicial
    }

    void Update()
    {
        FSM.Update();
    }
}
