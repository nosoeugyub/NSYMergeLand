using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager<T>
{
    private IState<T> currentState;

    public void ChangeState(IState<T> newState, T context)
    {
        if (currentState != null)
        {
            currentState.Exit(context);  // 현재 상태 Exit
        }

        currentState = newState;  // 새 상태로 변경
        if (currentState != null)
        {
            currentState.Enter(context);  // 새 상태 Enter
        }
    }

    public void Enter(T context)
    {
        // currentState가 null일 때 첫 상태를 설정하는 코드 추가
        if (currentState == null)
        {
            currentState.Enter(context);  // Enter 호출
        }
        else
        {
            currentState.Enter(context);  // 상태 진입
        }
    }

    public void Update(T context)
    {
        // currentState가 null인 경우도 체크
        if (currentState == null)
        {
            Debug.LogError("currentState is null! Cannot execute state.");
        }
        else
        {
            currentState.Excute(context);  // 상태 실행
        }
    }
}
