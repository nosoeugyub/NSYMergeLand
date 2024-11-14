using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter: MonoBehaviour
{
    public BaseCharacter()
    {
    }

    public BaseCharacter(BaseCharacterData _Charaterdata )
    {
        charaterdata = _Charaterdata;
    }

    public virtual void Init_Charaterdata(BaseCharacterData _Charaterdata)
    {
        charaterdata = _Charaterdata;
    }

    BaseCharacterData charaterdata;
    public BaseCharacterData Charaterdata
    {
        get
        {
            return charaterdata;
        }
        set
        {
            charaterdata = value;
        }
    }

    public StateManager<BaseCharacter> stateManager = new StateManager<BaseCharacter>();

    //활동중인지 아닌지 확인하는 bool
    private bool isActiveityInProgress;// 활동중인지아닌지
    public bool IsActivaityInProgress
    {
        get
        {
            return isActiveityInProgress;
        }
        set
        {
            isActiveityInProgress = value;
        }
    }

    public virtual void Create_Initialize(BaseCharacterData _CharacterData)
    {
        charaterdata = _CharacterData;
    }



    public virtual void UpdateNeeds()
    {
        RandomlyAdjustNeeds();
    }

    private void RandomlyAdjustNeeds()
    {
        // 예시: 배고픔, 피곤, 심심함 등의 욕구를 랜덤으로 조정
        Charaterdata.HurgryRage = Mathf.Clamp(Charaterdata.HurgryRage + UnityEngine.Random.Range(-3f, 3f), 0, 100);
        Charaterdata.BoringRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-1f, 2f), 0, 100);
        Charaterdata.WalkingRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 1f), 0, 100);
        Charaterdata.DefalutRage = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 3f), 0, 100);
        // 기타 욕구들도 추가 가능
    }


    //상태 변경 체크 메서드
    public virtual void CheckAndChargeState()
    {
        // 현재 상태를 가져와야만 이전 상태에서 작업이 완료된 후 새 상태로 변경할 수 있습니다.
        Utill_Eum.CharacterState state = BaseCharacterData.Get_NPCState(Charaterdata);
        switch (state)
        {
            case Utill_Eum.CharacterState.None:
                stateManager.ChangeState(new CharacterIdleState(this), this);  // 상태 변경
                break;
            case Utill_Eum.CharacterState.HurgryRage:
                stateManager.ChangeState(new CharacterHurgryState(this), this);  // 상태 변경
                break;
            case Utill_Eum.CharacterState.BoringRange:
                stateManager.ChangeState(new CharacterBoringState(this), this);  // 상태 변경
                break;
            case Utill_Eum.CharacterState.WalkingRange:
                stateManager.ChangeState(new CharacterWalkingState(this), this);  // 상태 변경
                break;
            case Utill_Eum.CharacterState.DefalutRage:
                stateManager.ChangeState(new CharacterIdleState(this), this);  // 상태 변경
                break;
        }
    }

    public void StartSate()
    {
        stateManager.Enter(this);
    }

    public void Update()
    {
        if (IsActivaityInProgress = true && Charaterdata != null)
        {
            UpdateNeeds();
            CheckAndChargeState(); // 상태 전환이 필요한지 검사 후 호출
            stateManager.Update(this);
        }
    }


    public void Init_CharacterData(BaseCharacterData Charaterdata)//Enter에서 주롯 사용
    {
        BaseCharacterData.Init_CharacterData(Charaterdata);
        IsActivaityInProgress = true;
    }

    public void Exit_CharacterData(BaseCharacterData Charaterdata)//Enter에서 주롯 사용
    {
        IsActivaityInProgress = true;
    }

}
