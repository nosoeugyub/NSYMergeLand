using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterData 
{
    //캐릭터들이 전체적으로 가졌으하는 욕구 

    //정적데이터
    //이름
    public int Name;
    //id
    public int Id;
    //설명
    public int Discription;
    //취향 날씨 타입
    public Utill_Eum.WeatherType LikeWeatherType;
    //성별(본인 성별)
    public Utill_Eum.AnimalGenderType MyGenderType;
    //이상형 ex) 선호성별 + 특성

    //기본 상태

    //동적데이터
    //레벨
    public int Level;
    //경험치
    public float Exp;
    //숙련도 레벨(숙련도에따라 작업능률이 올라감)
    public float WorkLevel;
    //상태(피곤)
    public float TiredRange;
    //상태 채집
    public float DigRange;

    //욕구 스텟(AI)
    //심심상태 (앉는 애니메이션)
    public float BoringRange;
    //산책 게이지 (활동)
    public float WalkingRange;
    //디폴트 게이지(가만히 서있는 애니메이션)
    public float DefalutRage;
    //배고픔(먹이를주면 신나하는 애니메이션)
    public float HurgryRage;

    // 로컬데이터
    //선호성별 (남. 여)
    //특성 (후각이 예민함 , 힘이 썜 )=> 채집확률 높아짐 : (* 가중치테이블로 곱해서 관리해야함)

    
    public static Utill_Eum.CharacterState Get_NPCState(BaseCharacterData data)//Get NPC STATE LOGS
    {
        if (data.BoringRange >= 100)
        {
            return Utill_Eum.CharacterState.BoringRange;
        }
        else if(data.WalkingRange >= 100)
        {
            return Utill_Eum.CharacterState.WalkingRange;
        }
        else if (data.DefalutRage >= 100)
        {
            return Utill_Eum.CharacterState.DefalutRage;
        }
        else if (data.HurgryRage >= 100)
        {
            return Utill_Eum.CharacterState.HurgryRage;
        }
        else
        {
            return Utill_Eum.CharacterState.None;
        }
    }

    internal static void Init_CharacterData(BaseCharacterData data)
    {
        data.BoringRange = 0;
        data.WalkingRange = 0;
        data.DefalutRage = 0;
        data.HurgryRage = 0;
    }
    //원하는 캐릭터 데이터찾는로직
    internal static BaseCharacterData Find_CharacterData(Dictionary<int, BaseCharacterData> CharacterDic, int Character_id)
    {
        BaseCharacterData data = null;

        if (CharacterDic.ContainsKey(Character_id))
        {
            data = CharacterDic[Character_id];
        }
        else
        {
            data = null;
        }

        return data;
    }

    //랜덤으로 데이터 찾아 내기
    internal static BaseCharacterData Find_RandomCharacterData(Dictionary<int, BaseCharacterData> CharacterDic)
    {
        BaseCharacterData data = null;

        // 딕셔너리가 비어있는지 확인
        if (CharacterDic == null || CharacterDic.Count == 0)
        {
            Debug.LogWarning("CharacterDic is empty or null.");
            return null;
        }

        // 딕셔너리의 키 목록을 가져옴
        List<int> keys = new List<int>(CharacterDic.Keys);

        // 랜덤 인덱스 선택 (0 이상 keys.Count 미만)
        int randomIndex = UnityEngine.Random.Range(0, keys.Count);

        // 랜덤 키를 사용하여 해당 데이터 가져오기
        int randomKey = keys[randomIndex];
        data = CharacterDic[randomKey];

        return data;
    }

    internal static void Add_NPCData(Dictionary<int, BaseCharacterData> UserCharacterDIc , int Character_id)//원하는 npc를 추가
    {
        //Character_id 아이디로 데이터찾기 
        BaseCharacterData data = Find_CharacterData(GameDataTable.Instance.CharacterDic, Character_id);
        UserCharacterDIc.Add(data.Id , data);
    }

    internal static void RandomAdd_NPCData(Dictionary<int, BaseCharacterData> UserCharacterDIc)//랜덤으로 추가
    {
        // 기존 UserCharacterDIc 딕셔너리에 중복이 없는 키값을 랜덤으로 찾아 더해주기
        // 딕셔너리의 모든 키를 리스트로 변환
        List<int> keys = new List<int>(UserCharacterDIc.Keys);

        // 중복되지 않는 랜덤 키 찾기
        int randomKey;
        do
        {
            randomKey = UnityEngine.Random.Range(1, GameDataTable.Instance.CharacterDic.Count);  // 임의의 키값 생성 (1부터 int.MaxValue까지)
        } while (keys.Contains(randomKey));  // 이미 존재하는 키가 있으면 다시 랜덤으로 생성

        BaseCharacterData data = GameDataTable.Instance.CharacterDic[randomKey];

        // 랜덤 키로 데이터를 UserCharacterDIc에 추가
        UserCharacterDIc.Add(randomKey, data);
    }

}
