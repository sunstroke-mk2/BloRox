using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : PlayersState
{
    public StateJump(PlayersSM _sm, PlayerFacade _ctrl) : base(_sm, _ctrl)
    {

    }

    public override void Enter()
    {
        Debug.Log("jump");
        myController.Jump();

    }

    public override void Execute()
    {
        mySM.ChangeState(PlayerStateEnum.inAir);
    }

    public override void Exit()
    {

    }
}
