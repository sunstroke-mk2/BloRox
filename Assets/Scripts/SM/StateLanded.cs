using UnityEngine;

public class StateLanded : PlayersState
{
    public StateLanded(PlayersSM _sm,PlayerController _ctrl) : base(_sm, _ctrl)
    {

    }

    public override void Enter()
    {
        Debug.Log("landed");
    }

    public override void Execute()
    {
        Vector3 inputData = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        myController.MoveCharacter(inputData);

        if (inputData != Vector3.zero)
        {
            myController.RotateCharacter(inputData);
        }
        if (Input.GetButton("Jump"))
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
