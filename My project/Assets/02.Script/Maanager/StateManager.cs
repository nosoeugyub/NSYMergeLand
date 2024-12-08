using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager<T>
{
    private IState<T> currentState;

    /// <summary>
    /// 현재 상태를 읽기 전용 속성으로 제공
    /// </summary>
    public IState<T> CurrentState => currentState;

    /// <summary>
    /// 상태 변경 메서드
    /// </summary>
    public void ChangeState(IState<T> newState, T context)
    {
        if (newState == null)
        {
            Debug.LogError("Attempted to change to a null state.");
            return;
        }

        currentState?.Exit(context); // 이전 상태 Exit 호출
        currentState = newState;
        currentState.Enter(context); // 새로운 상태 Enter 호출
    }

    /// <summary>
    /// 현재 상태를 업데이트
    /// </summary>
    public void Update(T context)
    {
        if (currentState == null)
        {
            Debug.LogWarning("No current state to update.");
            return;
        }

        currentState.Excute(context); // 현재 상태 실행
    }

    /// <summary>
    /// 특정 상태로 진입
    /// </summary>
    public void Enter(T context)
    {
        if (currentState == null)
        {
            Debug.LogWarning("Cannot enter a state as no initial state is set.");
            return;
        }

        currentState.Enter(context);
    }
}
