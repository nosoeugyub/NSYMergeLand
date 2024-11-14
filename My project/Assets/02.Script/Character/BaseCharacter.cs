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
        // ����: �����, �ǰ�, �ɽ��� ���� �屸�� �������� ����
        Charaterdata.HurgryRage = Mathf.Clamp(Charaterdata.HurgryRage + UnityEngine.Random.Range(-3f, 3f), 0, 100);
        Charaterdata.BoringRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-1f, 2f), 0, 100);
        Charaterdata.WalkingRange = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 1f), 0, 100);
        Charaterdata.DefalutRage = Mathf.Clamp(Charaterdata.BoringRange + UnityEngine.Random.Range(-2f, 3f), 0, 100);
        // ��Ÿ �屸�鵵 �߰� ����
    }


    //���� ���� üũ �޼���
    public virtual void CheckAndChargeState()
    {
        // ���� ���¸� �����;߸� ���� ���¿��� �۾��� �Ϸ�� �� �� ���·� ������ �� �ֽ��ϴ�.
        Utill_Eum.CharacterState state = BaseCharacterData.Get_NPCState(Charaterdata);
        switch (state)
        {
            case Utill_Eum.CharacterState.None:
                stateManager.ChangeState(new CharacterIdleState(this), this);  // ���� ����
                break;
            case Utill_Eum.CharacterState.HurgryRage:
                stateManager.ChangeState(new CharacterHurgryState(this), this);  // ���� ����
                break;
            case Utill_Eum.CharacterState.BoringRange:
                stateManager.ChangeState(new CharacterBoringState(this), this);  // ���� ����
                break;
            case Utill_Eum.CharacterState.WalkingRange:
                stateManager.ChangeState(new CharacterWalkingState(this), this);  // ���� ����
                break;
            case Utill_Eum.CharacterState.DefalutRage:
                stateManager.ChangeState(new CharacterIdleState(this), this);  // ���� ����
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
            CheckAndChargeState(); // ���� ��ȯ�� �ʿ����� �˻� �� ȣ��
            stateManager.Update(this);
        }
    }


    public void Init_CharacterData(BaseCharacterData Charaterdata)//Enter���� �ַ� ���
    {
        BaseCharacterData.Init_CharacterData(Charaterdata);
        IsActivaityInProgress = true;
    }

    public void Exit_CharacterData(BaseCharacterData Charaterdata)//Enter���� �ַ� ���
    {
        IsActivaityInProgress = true;
    }

}
