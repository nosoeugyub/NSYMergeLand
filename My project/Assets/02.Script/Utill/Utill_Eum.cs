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


    public enum WeatherType //���� Ÿ��
    {
        Clear, //����
        Blur,  //�帲
        Rain,  //��
    }

    public enum AnimalGenderType//���� ����
    {
        Man,
        Woman,
    }
}
