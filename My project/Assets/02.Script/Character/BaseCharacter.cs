using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter 
{
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
    private bool isActiveityInProgress = false;// Ȱ���������ƴ���
    public bool IsActivaityInProgress
    {
        get
        {
            return isActiveityInProgress;
        }
        set
        {
            value = isActiveityInProgress;
        }
    }

    public virtual void UpdateNeeds()
    {
        if (IsActivaityInProgress)
        {
            RandomlyAdjustNeeds();
            CheckAndChargeState();
        }
       
    }

    private void RandomlyAdjustNeeds()
    {
        // ����: �����, �ǰ�, �ɽ��� ���� �屸�� �������� ����
        Charaterdata.HurgryRage = Mathf.Clamp(Charaterdata.HurgryRage + UnityEngine.Random.Range(-1f, 3f), 0, 100);
        Charaterdata.TiredRange = Mathf.Clamp(Charaterdata.TiredRange + UnityEngine.Random.Range(-1f, 2f), 0, 100);
        Charaterdata.Boring = Mathf.Clamp(Charaterdata.Boring + UnityEngine.Random.Range(-1f, 2f), 0, 100);
        // ��Ÿ �屸�鵵 �߰� ����
    }

    public virtual void CheckAndChargeState()//���� ���� üũ �޼���
    {
        
    }

    public void Update()
    {
        UpdateNeeds();
        stateManager.Update(this);
    }
}
