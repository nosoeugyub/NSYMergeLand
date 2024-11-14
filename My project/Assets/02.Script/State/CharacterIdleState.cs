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
        //������ ������ �ʱ�ȭ
        context.Init_CharacterData(context.Charaterdata);
        Debug.Log("���̵� ����");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("���̵� ��");
    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("���̵� ����");
    }
}
