using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager<T>
{
    private IState<T> currentState;

    public void ChangeState(IState<T> newState , T context)
    {
        currentState?.Exit(context); //���� ���¿��� exit ȣ��
        currentState = newState;     //���ο� ���·� �����
        currentState?.Enter(context); //���ο� ���� ����
    }

    public void Update(T context)
    {
        currentState?.Excute(context);
    }
}
