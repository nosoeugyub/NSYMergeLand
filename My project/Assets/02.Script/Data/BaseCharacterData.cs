using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterData 
{
    //ĳ���͵��� ��ü������ �������ϴ� �屸 

    //����������
    //�̸�
    public string Name;
    //id
    public int Id;
    //����
    public string Discription;
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

    //�屸 ����
    //�ɽɻ��� (�ɴ� �ִϸ��̼�)
    public float Boring;
    //��å ������ (Ȱ��)
    public float WalkingRange;
    //����Ʈ ������(������ ���ִ� �ִϸ��̼�)
    public float DefalutRage;
    //�����(���̸��ָ� �ų��ϴ� �ִϸ��̼�)
    public float HurgryRage;

    // ���õ�����
    //��ȣ���� (��. ��)
    //Ư�� (�İ��� ������ , ���� �� )=> ä��Ȯ�� ������ : (* ����ġ���̺�� ���ؼ� �����ؾ���)
}
