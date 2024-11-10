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
    #region ������ �ε�
    public void DataLoad()//���������� �ε�
    {
        //���� ������ �Ҵ�
       GameDataTable.Instance.CharacterDic =  CSVReader.Read_BaseCharacte_data(TagLayerString.DataLoadCharacter);//���̺� �ִ� NPC������


        //���������� �Ҵ�
        GameDataTable.Instance.UserData = CSVReader.Read_Userdata(TagLayerString.UserData);//����������
        GameDataTable.Instance.UserCharacterDIc = CSVReader.Read_UserBaseCharacte_data(TagLayerString.UserDataLoadCharacter); //������ŉ���� NPC

        if (GameDataTable.Instance.UserData.Level == -1)//������ ����
        {

        }
        else//�̾��ϱ� ����
        {
            
        }
    }

    public void UserLocalDataLoad() //���� & ���������� �ε�
    {

    }

    #endregion

    ////////////////
    /// Data Save
    ////////////////
    ///
    #region ������ ����
    public void AllSaveData()
    {
        SaveUserCharacterData();
        SaveUserData();
    }

    public void SaveUserCharacterData()//������ ŉ���� ĳ���͵� ����
    {
        CSVWriter.WriteDictionaryToCSV(TagLayerString.UserDataLoadCharacter+".csv" , GameDataTable.Instance.UserCharacterDIc, GameDataTable.Instance.headersuserchardata);
    }

    public void SaveUserData()//���� ������ ����
    {
        CSVWriter.WriteUserDataToCSV(TagLayerString.UserData + ".csv", GameDataTable.Instance.UserData, GameDataTable.Instance.headersuserdata);
    }

    #endregion

}
