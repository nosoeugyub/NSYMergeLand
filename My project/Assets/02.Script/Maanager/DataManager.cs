using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Start()
    {
        GameEventSystem.Game_Sequence_Event += GameDataLoad;
    }

    private void GameDataLoad(Utill_Eum.GameSequence Gamesequence)
    {
        switch (Gamesequence)
        {
            case Utill_Eum.GameSequence.DataLoad:
                DataLoad();
                break;
            case Utill_Eum.GameSequence.CreateData:
                break;
            case Utill_Eum.GameSequence.Tutorial:
                break;
            case Utill_Eum.GameSequence.GameSetting:
                break;
            case Utill_Eum.GameSequence.GameStart:
                break;
            default:
                break;
        }
    }




    ////////////////
    /// Data Load
    ////////////////
    ///
    #region 데이터 로드
    public void DataLoad()//정적데이터 로드
    {
        //정적 데이터 할당
       GameDataTable.Instance.CharacterDic =  CSVReader.Read_BaseCharacte_data(TagLayerString.DataLoadCharacter);//테이블에 있는 NPC데이터


        //동적데이터 할당
        GameDataTable.Instance.UserData = CSVReader.Read_Userdata(TagLayerString.UserData);//유저데이터
        GameDataTable.Instance.UserCharacterDIc = CSVReader.Read_UserBaseCharacte_data(TagLayerString.UserDataLoadCharacter); //유저가흭득한 NPC

        if (GameDataTable.Instance.UserData.Level == -1)//새게임 로직
        {

        }
        else//이어하기 로직
        {
            
        }
    }

    public void UserLocalDataLoad() //유저 & 동적데이터 로드
    {

    }

    #endregion

    ////////////////
    /// Data Save
    ////////////////
    ///
    #region 데이터 저장
    public void AllSaveData()
    {
        SaveUserCharacterData();
        SaveUserData();
    }

    public void SaveUserCharacterData()//유저가 흭득한 캐릭터들 저장
    {
        CSVWriter.WriteDictionaryToCSV(TagLayerString.UserDataLoadCharacter+".csv" , GameDataTable.Instance.UserCharacterDIc, GameDataTable.Instance.headersuserchardata);
    }

    public void SaveUserData()//유저 데이터 저장
    {
        CSVWriter.WriteUserDataToCSV(TagLayerString.UserData + ".csv", GameDataTable.Instance.UserData, GameDataTable.Instance.headersuserdata);
    }

    #endregion

}
