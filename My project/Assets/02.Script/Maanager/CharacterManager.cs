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
        // Add_NPCData에서 NPC 데이터를 받아옵니다.
        BaseCharacterData data = BaseCharacterData.Add_NPCData(GameDataTable.Instance.UserCharacterDIc, Id);

        if (data == null)
        {
            Debug.LogWarning($"ID {Id}에 해당하는 NPC 데이터를 찾을 수 없습니다.");
            return;
        }

        if (GameDataTable.Instance.CharacterDic.TryGetValue(data.Id, out BaseCharacterData characterData))
        {
            CreateNPC(characterData);
        }
        else
        {
            Debug.LogWarning($"ID {data.Id}에 해당하는 캐릭터 데이터가 CharacterDic에 없습니다.");
        }
    }

    // NPC 오브젝트 생성 함수
    public void CreateNPC(BaseCharacterData characterData)
    {
        if (NPCLIST.Count <= 0)
        {
            return;
        }

        int id = characterData.Id;

        // 인덱스 범위 체크
        if (id < 0 || id >= NPCLIST.Count)
        {
            Debug.LogError($"ID {id}가 NPC 리스트 범위를 초과했습니다.");
            return;
        }

        if (NPCLIST[id] == null)
        {
            Debug.LogWarning($"NPC 리스트의 ID {id} 위치에 오브젝트가 존재하지 않습니다.");
            return;
        }

        // NPC 활성화 및 초기화
        NPCLIST[id].gameObject.SetActive(true);
        NPCLIST[id].Create_Initialize(characterData);
        // 상태를 Idle로 설정
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
