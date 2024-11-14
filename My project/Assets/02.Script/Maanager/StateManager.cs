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
            currentState.Exit(context);  // ���� ���� Exit
        }

        currentState = newState;  // �� ���·� ����
        if (currentState != null)
        {
            currentState.Enter(context);  // �� ���� Enter
        }
    }

    public void Enter(T context)
    {
        // currentState�� null�� �� ù ���¸� �����ϴ� �ڵ� �߰�
        if (currentState == null)
        {
            currentState.Enter(context);  // Enter ȣ��
        }
        else
        {
            currentState.Enter(context);  // ���� ����
        }
    }

    public void Update(T context)
    {
        // currentState�� null�� ��쵵 üũ
        if (currentState == null)
        {
            Debug.LogError("currentState is null! Cannot execute state.");
        }
        else
        {
            currentState.Excute(context);  // ���� ����
        }
    }
}
