public class UserData 
{
    public string User_Id;
    public int Level = -1;
    public float Exp;
    public string UserLastLogin;
    public string Version;

    //Data
    public BaseCharacterData UserCharacterData;


    public static void Init_UserCharacterData(UserData userdat , BaseCharacterData _data)//���� ĳ���� ������ �Ҵ�
    {
        userdat.UserCharacterData = _data;
    }
}
