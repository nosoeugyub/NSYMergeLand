using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager<T>
{
    private IState<T> currentState;

    public void ChangeState(IState<T> newState , T context)
    {
        currentState?.Exit(context); //현태 상태에서 exit 호출
        currentState = newState;     //새로운 상태로 만들기
        currentState?.Enter(context); //새로운 상태 시작
    }

    public void Update(T context)
    {
        currentState?.Excute(context);
    }
}
