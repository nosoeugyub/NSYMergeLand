using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//가장 기본이 되는 NPC 베이스 로직
public class CatA : BaseCharacter
{



    public override void UpdateNeeds()//실시간 욕구 증가 함수
    {
        base.UpdateNeeds();
    }

    public override void CheckAndChargeState() //해당 욕구에 대한 해동 변환 함수
    {
      Utill_Eum.CharacterState state =  BaseCharacterData.Get_NPCState(Charaterdata);
        switch (state)
        {
            case Utill_Eum.CharacterState.None:
                stateManager.ChangeState(new CharacterIdleState(this), this);
                break;
            case Utill_Eum.CharacterState.HurgryRage:
                stateManager.ChangeState(new CharacterIdleState(this), this);
                break;
            case Utill_Eum.CharacterState.BoringRange:
                stateManager.ChangeState(new CharacterIdleState(this), this);
                break;
            case Utill_Eum.CharacterState.WalkingRange:
                stateManager.ChangeState(new CharacterIdleState(this), this);
                break;
            case Utill_Eum.CharacterState.DefalutRage:
                stateManager.ChangeState(new CharacterIdleState(this), this);
                break;
        }




    }
}
