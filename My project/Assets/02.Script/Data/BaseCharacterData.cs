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
}
