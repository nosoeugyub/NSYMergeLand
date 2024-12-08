using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter�� �Ű������� �޴� ������
    public CharacterIdleState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        if (context.Charaterdata == null)
        {
            context.Charaterdata = character.Charaterdata;
        }

        //������ ������ �ʱ�ȭ
        context.Init_CharacterData(context.Charaterdata);
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("���̵� ��");
    }


    public void Exit(BaseCharacter context)
    {
    }
}
