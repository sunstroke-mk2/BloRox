using UnityEngine;

public class StateInAir : PlayersState
{
    public StateInAir(PlayersSM _sm, PlayerFacade _ctrl) : base(_sm, _ctrl)
    {

    }

    public override void Enter()
    {
        Debug.Log("inAir");
    }

    public override void Execute()
    {
        Vector3 inputData = InputHandler.Instance.InputData;
        myController.MoveCharacter(inputData);

        if (inputData != Vector3.zero)
        {
            myController.RotateCharacter(inputData);
        }


        if (myController.isGrounded())
        {
            mySM.ChangeState(PlayerStateEnum.landed);
        }
    }

    public override void Exit()
    {

    }
}
