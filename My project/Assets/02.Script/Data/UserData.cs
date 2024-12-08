public class UserData 
{
    public string User_Id;
    public int Level = -1;
    public float Exp;
    public string UserLastLogin;
    public string Version;

    //Data
    public BaseCharacterData UserCharacterData;


    public static void Init_UserCharacterData(UserData userdat , BaseCharacterData _data)//유저 캐릭터 데이터 할당
    {
        userdat.UserCharacterData = _data;
    }
}
