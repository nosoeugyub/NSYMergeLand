using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utill_Eum 
{
    public enum GameSequence
    {
        DataLoad,
        CreateData,
        Tutorial,
        GameSetting,
        GameStart,
    }



    public enum CharacterState
    {
       None,
       HurgryRage ,
       BoringRange ,
       WalkingRange,
       DefalutRage 
    }


    public enum WeatherType //날씨 타입
    {
        Clear, //말음
        Blur,  //흐림
        Rain,  //비
    }

    public enum AnimalGenderType//동물 성별
    {
        Man,
        Woman,
    }
}
