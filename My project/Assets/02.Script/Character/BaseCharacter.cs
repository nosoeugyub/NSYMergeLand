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

    //Ȱ�������� �ƴ��� Ȯ���ϴ� bool
    private bool isActiveityInProgress;// Ȱ���������ƴ���
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
        // ����: �����, �ǰ�, �ɽ��� ���� �屸�� �������� ����
        Charaterdata.HurgryRage = Mathf.Clamp(Charaterdata.HurgryRage + UnityEngine.Random.Range(-3f, 3f), 0, 100);
        Charaterdata.BoringRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-1f, 2f), 0, 100);
        Charaterdata.WalkingRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 1f), 0, 100);
        Charaterdata.DefalutRage = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 3f), 0, 100);
        // ��Ÿ �屸�鵵 �߰� ����
    }

    public virtual void CheckAndChargeState(){ }//���� ���� üũ �޼���

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
