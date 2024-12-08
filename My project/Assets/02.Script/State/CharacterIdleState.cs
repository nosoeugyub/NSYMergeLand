using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter를 매개변수로 받는 생성자
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

        //나갈시 데이터 초기화
        context.Init_CharacterData(context.Charaterdata);
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("아이들 중");
    }


    public void Exit(BaseCharacter context)
    {
    }
}
