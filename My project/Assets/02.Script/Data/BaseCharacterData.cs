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
}
