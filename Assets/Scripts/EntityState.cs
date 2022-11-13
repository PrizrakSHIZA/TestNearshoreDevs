using UnityEngine;
using UnityEngine.Events;

public class EntityState : MonoBehaviour
{
    public States CurrentState => currentState;

    public UnityEvent<States> StateChanged;

    States currentState;

    CharacterController2D cc;
    Rigidbody2D rb;
    PlayerMovement pm;

    void Start()
    {
        currentState = States.idle;
        cc = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //idle + waliking
        if (Mathf.Abs(rb.velocity.x) > .1f && cc.Grounded)
            ChangeState(States.running);
        else if (Mathf.Abs(rb.velocity.x) < .1f && cc.Grounded)
            ChangeState(States.idle);
        // jump and air
        // This will execute Jump_start animation even if character will be launched upward for external forces (not only jump)
        // and should be changed, depending on game mechanics
        else if (!cc.Grounded && rb.velocity.y > .1f)
            ChangeState(States.jump);
        else if (!cc.Grounded && rb.velocity.y < -.1f)
            ChangeState(States.inAir);
    }

    public void ChangeState(States toState)
    {
        if(currentState == toState)
            return;
        currentState = toState;
        StateChanged.Invoke(toState);
    }

    public enum States
    {
        idle,
        running,
        jump,
        inAir,
        dead,
    }
}