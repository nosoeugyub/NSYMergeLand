using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : IState<Game>
{
    public void Enter(Game context)
    {
        context.EnterGameStart();
    }

    public void Excute(Game context)
    {
        context.EnterGameExcute();
    }

    public void Exit(Game Context)
    {
        Context.EnterGameExit();
    }
}
