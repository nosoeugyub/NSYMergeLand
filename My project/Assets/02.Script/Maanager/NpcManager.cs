using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager _instance;
    public List<BaseCharacter> NPCLIST;

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

        GameEventSystem.AddNpc_Event += AddNpc;
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
