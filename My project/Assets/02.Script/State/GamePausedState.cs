using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : IState<Game>
{
    public void Enter(Game context)
    {
        //게임이 일시정지할떄 들어갈 로직
        context.PauseGame();
    }

    public void Excute(Game context)
    {
        //게임이 일시정지 중일 때 나오는 로직
        context.UpdateGamePause(); 
    }

    public void Exit(Game Context)
    {
        //게임이 일시정지에서 나갈떄 나오는 로직
        Context.ExitGamePause();
    }
}
