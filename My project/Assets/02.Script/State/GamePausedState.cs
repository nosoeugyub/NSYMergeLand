using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : IState<Game>
{
    public void Enter(Game context)
    {
        //������ �Ͻ������ҋ� �� ����
        context.PauseGame();
    }

    public void Excute(Game context)
    {
        //������ �Ͻ����� ���� �� ������ ����
        context.UpdateGamePause(); 
    }

    public void Exit(Game Context)
    {
        //������ �Ͻ��������� ������ ������ ����
        Context.ExitGamePause();
    }
}
