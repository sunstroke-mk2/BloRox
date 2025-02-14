using System.Collections.Generic;
using UnityEngine;

public class PlayersSM : MonoBehaviour
{
    public PlayerController PlayerController;
    Dictionary<PlayerStateEnum, PlayersState> states=new Dictionary<PlayerStateEnum, PlayersState>();
    private PlayersState currentState;
    private void Start()
    {
        states.Add(PlayerStateEnum.landed, new StateLanded(this,PlayerController));
        states.Add(PlayerStateEnum.inAir, new StateInAir(this,PlayerController));
        states.Add(PlayerStateEnum.jump, new StateJump(this,PlayerController));
        ChangeState(PlayerStateEnum.landed);
    }

    private void FixedUpdate()
    {
        currentState.Execute();
    }
    public void ChangeState(PlayerStateEnum _newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = states[_newState];
        currentState.Enter();
    }
}
