public abstract class PlayersState
{
    protected PlayersSM mySM;
    protected PlayerController myController;
    private PlayersSM sm;

    public PlayersState(PlayersSM _sm, PlayerController _controller)
    {
        mySM = _sm;
        myController = _controller;
    }

    protected PlayersState(PlayersSM sm)
    {
        this.sm = sm;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();

}
