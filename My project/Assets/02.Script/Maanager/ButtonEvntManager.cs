using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvntManager : MonoBehaviour
{
    public void AddNPC() //npc�� ���������߰�
    {
        BaseCharacterData.Add_NPCData(GameDataTable.Instance.UserCharacterDIc , 1);
    }

   public void RandomAddNpc()//�������� �����ֱ�
    {
        BaseCharacterData.RandomAdd_NPCData(GameDataTable.Instance.UserCharacterDIc);
    }

    public void ClearNpc()
    {

    }
}
   