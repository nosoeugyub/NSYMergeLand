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

    public virtual void Initialize(BaseCharacterData _CharacterData)
    {
        charaterdata = _CharacterData;
    }

    public virtual void UpdateNeeds()
    {
        if (!IsActivaityInProgress)
        {
            RandomlyAdjustNeeds();
            CheckAndChargeState();
        }
       
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

    public virtual void CheckAndChargeState(){ }//상태 변경 체크 메서드

    public void Update()
    {
        UpdateNeeds();
        stateManager.Update(this);
    }


    public void Init_CharacterData(BaseCharacterData data)
    {
        BaseCharacterData.Init_CharacterData(data);
        IsActivaityInProgress = false;
    }
}
