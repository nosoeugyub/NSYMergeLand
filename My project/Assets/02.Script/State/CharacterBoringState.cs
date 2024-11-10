using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoringState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter�� �Ű������� �޴� ������
    public CharacterBoringState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("������ ����");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("������ ����");
    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("������ ��");
    }
}
