using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHurgryState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter를 매개변수로 받는 생성자
    public CharacterHurgryState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("배고픔 시작");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("배고픔 나감");
    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("배고픔 중");
    }
}
