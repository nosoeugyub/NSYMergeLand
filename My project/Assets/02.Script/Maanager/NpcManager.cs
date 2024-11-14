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
