using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvntManager : MonoBehaviour
{
    public void AddNPC(int i) //npc�� ���������߰�
    {
        GameEventSystem.Send_AddNpc(i);
    }

   public void RandomAddNpc()//�������� �����ֱ�
    {
        BaseCharacterData.RandomAdd_NPCData(GameDataTable.Instance.UserCharacterDIc);
    }

    public void ClearNpc()
    {

    }
}
   