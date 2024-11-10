using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefalutState : IState<BaseCharacter>
{
    private BaseCharacter character;

    // BaseCharacter를 매개변수로 받는 생성자
    public CharacterDefalutState(BaseCharacter character)
    {
        this.character = character;
    }

    public void Enter(BaseCharacter context)
    {
        Debug.Log("디폴트 시작");
    }

    public void Excute(BaseCharacter context)
    {
        Debug.Log("디폴트 나감");
    }


    public void Exit(BaseCharacter context)
    {
        Debug.Log("디폴트 중");
    }
}
