using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkingState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter�� �Ű������� �޴� ������
    public CharacterWalkingState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("�ȱ� ����");
        //������ ������ �ʱ�ȭ
        character.Init_CharacterData(character.Charaterdata);
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("�ȱ� ����");
        

    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("�ȱ� ��");

    }
}
