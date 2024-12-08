using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager _instance;
    public List<BaseCharacter> NPCLIST;

    [SerializeField] BaseCharacter Player;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        GameEventSystem.Game_Sequence_Event += SetGameCharacterState;
        GameEventSystem.AddNpc_Event += AddNpc;
    }

    private void SetGameCharacterState(Utill_Eum.GameSequence Gamesequence)
    {
        switch (Gamesequence)
        {
            case Utill_Eum.GameSequence.GameStart://GameStart in SetCharacter State
                InitIdle_CharaterState(Player);
                break;

        }
    }
    private void InitIdle_CharaterState(BaseCharacter _Chatacter)
    {
        _Chatacter.stateManager.ChangeState(new CharacterIdleState(_Chatacter), _Chatacter);
    }

    private void SetCharaterState(BaseCharacter _Chatacter , Utill_Eum.StateType Type)
    {
        switch (Type)
        {
            case Utill_Eum.StateType.Idle:
                _Chatacter.stateManager.ChangeState(new CharacterIdleState(_Chatacter), _Chatacter);
                break;
            case Utill_Eum.StateType.Walk:
                _Chatacter.stateManager.ChangeState(new CharacterWalkingState(_Chatacter), _Chatacter);
                break;
            case Utill_Eum.StateType.Hungry:
                _Chatacter.stateManager.ChangeState(new CharacterHurgryState(_Chatacter), _Chatacter);
                break;
            case Utill_Eum.StateType.Boring:
                _Chatacter.stateManager.ChangeState(new CharacterBoringState(_Chatacter), _Chatacter);
                break;
            default:
                break;
        }

    }

    private void OnDestroy()
    {
        GameEventSystem.AddNpc_Event -= AddNpc;
    }

    private void AddNpc(int Id)
    {
        // Add_NPCData���� NPC �����͸� �޾ƿɴϴ�.
        BaseCharacterData data = BaseCharacterData.Add_NPCData(GameDataTable.Instance.UserCharacterDIc, Id);

        if (data == null)
        {
            Debug.LogWarning($"ID {Id}�� �ش��ϴ� NPC �����͸� ã�� �� �����ϴ�.");
            return;
        }

        if (GameDataTable.Instance.CharacterDic.TryGetValue(data.Id, out BaseCharacterData characterData))
        {
            CreateNPC(characterData);
        }
        else
        {
            Debug.LogWarning($"ID {data.Id}�� �ش��ϴ� ĳ���� �����Ͱ� CharacterDic�� �����ϴ�.");
        }
    }

    // NPC ������Ʈ ���� �Լ�
    public void CreateNPC(BaseCharacterData characterData)
    {
        if (NPCLIST.Count <= 0)
        {
            return;
        }

        int id = characterData.Id;

        // �ε��� ���� üũ
        if (id < 0 || id >= NPCLIST.Count)
        {
            Debug.LogError($"ID {id}�� NPC ����Ʈ ������ �ʰ��߽��ϴ�.");
            return;
        }

        if (NPCLIST[id] == null)
        {
            Debug.LogWarning($"NPC ����Ʈ�� ID {id} ��ġ�� ������Ʈ�� �������� �ʽ��ϴ�.");
            return;
        }

        // NPC Ȱ��ȭ �� �ʱ�ȭ
        NPCLIST[id].gameObject.SetActive(true);
        NPCLIST[id].Create_Initialize(characterData);
        // ���¸� Idle�� ����
        if (NPCLIST[id].stateManager == null)
        {
            Debug.LogError("StateManager is not initialized!");
            return;
        }
        else
        {
            NPCLIST[id].stateManager.ChangeState(new CharacterIdleState(NPCLIST[id]), NPCLIST[id]);
        }
       
    }
}
