using UnityEngine;

public class StateLanded : PlayersState
{
    public StateLanded(PlayersSM _sm,PlayerFacade _ctrl) : base(_sm, _ctrl)
    {

    }

    public override void Enter()
    {
        Debug.Log("landed");
    }

    public override void Execute()
    {
        Vector3 inputData = InputHandler.Instance.InputData;

        myController.MoveCharacter(inputData);

        if (inputData != Vector3.zero)
        {
            myController.RotateCharacter(inputData);
        }
        if (InputHandler.Instance.Jump)
        {
            mySM.ChangeState(PlayerStateEnum.jump);
        }
        if(!myController.isGrounded())
        {
            mySM.ChangeState(PlayerStateEnum.inAir);
        }
    }

    public override void Exit()
    {

    }
}
