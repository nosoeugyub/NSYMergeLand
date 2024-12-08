using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager<T>
{
    private IState<T> currentState;

    /// <summary>
    /// ���� ���¸� �б� ���� �Ӽ����� ����
    /// </summary>
    public IState<T> CurrentState => currentState;

    /// <summary>
    /// ���� ���� �޼���
    /// </summary>
    public void ChangeState(IState<T> newState, T context)
    {
        if (newState == null)
        {
            Debug.LogError("Attempted to change to a null state.");
            return;
        }

        currentState?.Exit(context); // ���� ���� Exit ȣ��
        currentState = newState;
        currentState.Enter(context); // ���ο� ���� Enter ȣ��
    }

    /// <summary>
    /// ���� ���¸� ������Ʈ
    /// </summary>
    public void Update(T context)
    {
        if (currentState == null)
        {
            Debug.LogWarning("No current state to update.");
            return;
        }

        currentState.Excute(context); // ���� ���� ����
    }

    /// <summary>
    /// Ư�� ���·� ����
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
