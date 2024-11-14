using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvntManager : MonoBehaviour
{
    public void AddNPC(int i) //npc를 랜덤으로추가
    {
        GameEventSystem.Send_AddNpc(i);
    }

   public void RandomAddNpc()//랜덤으로 더해주기
    {
        BaseCharacterData.RandomAdd_NPCData(GameDataTable.Instance.UserCharacterDIc);
    }

    public void ClearNpc()
    {

    }
}
   