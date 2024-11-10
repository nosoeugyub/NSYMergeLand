using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterData 
{
    //ĳ���͵��� ��ü������ �������ϴ� �屸 

    //����������
    //�̸�
    public int Name;
    //id
    public int Id;
    //����
    public int Discription;
    //���� ���� Ÿ��
    public Utill_Eum.WeatherType LikeWeatherType;
    //����(���� ����)
    public Utill_Eum.AnimalGenderType MyGenderType;
    //�̻��� ex) ��ȣ���� + Ư��

    //�⺻ ����

    //����������
    //����
    public int Level;
    //����ġ
    public float Exp;
    //���õ� ����(���õ������� �۾��ɷ��� �ö�)
    public float WorkLevel;
    //����(�ǰ�)
    public float TiredRange;
    //���� ä��
    public float DigRange;

    //�屸 ����(AI)
    //�ɽɻ��� (�ɴ� �ִϸ��̼�)
    public float BoringRange;
    //��å ������ (Ȱ��)
    public float WalkingRange;
    //����Ʈ ������(������ ���ִ� �ִϸ��̼�)
    public float DefalutRage;
    //�����(���̸��ָ� �ų��ϴ� �ִϸ��̼�)
    public float HurgryRage;

    // ���õ�����
    //��ȣ���� (��. ��)
    //Ư�� (�İ��� ������ , ���� �� )=> ä��Ȯ�� ������ : (* ����ġ���̺�� ���ؼ� �����ؾ���)

    
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
    //���ϴ� ĳ���� ������ã�·���
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

    //�������� ������ ã�� ����
    internal static BaseCharacterData Find_RandomCharacterData(Dictionary<int, BaseCharacterData> CharacterDic)
    {
        BaseCharacterData data = null;

        // ��ųʸ��� ����ִ��� Ȯ��
        if (CharacterDic == null || CharacterDic.Count == 0)
        {
            Debug.LogWarning("CharacterDic is empty or null.");
            return null;
        }

        // ��ųʸ��� Ű ����� ������
        List<int> keys = new List<int>(CharacterDic.Keys);

        // ���� �ε��� ���� (0 �̻� keys.Count �̸�)
        int randomIndex = UnityEngine.Random.Range(0, keys.Count);

        // ���� Ű�� ����Ͽ� �ش� ������ ��������
        int randomKey = keys[randomIndex];
        data = CharacterDic[randomKey];

        return data;
    }

    internal static void Add_NPCData(Dictionary<int, BaseCharacterData> UserCharacterDIc , int Character_id)//���ϴ� npc�� �߰�
    {
        //Character_id ���̵�� ������ã�� 
        BaseCharacterData data = Find_CharacterData(GameDataTable.Instance.CharacterDic, Character_id);
        UserCharacterDIc.Add(data.Id , data);
    }

    internal static void RandomAdd_NPCData(Dictionary<int, BaseCharacterData> UserCharacterDIc)//�������� �߰�
    {
        // ���� UserCharacterDIc ��ųʸ��� �ߺ��� ���� Ű���� �������� ã�� �����ֱ�
        // ��ųʸ��� ��� Ű�� ����Ʈ�� ��ȯ
        List<int> keys = new List<int>(UserCharacterDIc.Keys);

        // �ߺ����� �ʴ� ���� Ű ã��
        int randomKey;
        do
        {
            randomKey = UnityEngine.Random.Range(1, GameDataTable.Instance.CharacterDic.Count);  // ������ Ű�� ���� (1���� int.MaxValue����)
        } while (keys.Contains(randomKey));  // �̹� �����ϴ� Ű�� ������ �ٽ� �������� ����

        BaseCharacterData data = GameDataTable.Instance.CharacterDic[randomKey];

        // ���� Ű�� �����͸� UserCharacterDIc�� �߰�
        UserCharacterDIc.Add(randomKey, data);
    }

}
