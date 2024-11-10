using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkingState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter를 매개변수로 받는 생성자
    public CharacterWalkingState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("걷기 시작");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("걷기 나감");
        //나갈시 데이터 초기화
        character.Init_CharacterData(character.Charaterdata);

    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("걷기 중");

    }
}
