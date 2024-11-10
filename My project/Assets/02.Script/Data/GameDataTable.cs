using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTable 
{
    public List<string> headersuserchardata = new List<string> { "Name", "Id", "Description", "LikeWeatherType", "MyGenderType" };
    public List<string> headersuserdata = new List<string> { "User_Id", "Level", "Exp", "UserLastLogin", "Version" };


    // Static
    public Dictionary<int, BaseCharacterData> CharacterDic; //NPC들의 데이터
 



    //User
    public UserData UserData; //유저 데이터
    public Dictionary<int, BaseCharacterData> UserCharacterDIc; //유저가 흭득한 NPC 



    // Singleton instance
    private static GameDataTable _instance;

    // Private constructor for singleton pattern
    private GameDataTable()
    {
        CharacterDic = new Dictionary<int, BaseCharacterData>();
    }

    // Public property to access the singleton instance
    public static GameDataTable Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameDataTable();
            }
            return _instance;
        }
    }

}
