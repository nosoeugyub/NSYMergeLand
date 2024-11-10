using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefalutState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter�� �Ű������� �޴� ������
    public CharacterDefalutState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("����Ʈ ����");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("����Ʈ ����");
    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("����Ʈ ��");
    }
}
