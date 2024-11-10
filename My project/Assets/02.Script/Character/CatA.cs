using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �⺻�� �Ǵ� NPC ���̽� ����
public class CatA : BaseCharacter
{



    public override void UpdateNeeds()//�ǽð� �屸 ���� �Լ�
    {
        base.UpdateNeeds();
    }

    public override void CheckAndChargeState() //�ش� �屸�� ���� �ص� ��ȯ �Լ�
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