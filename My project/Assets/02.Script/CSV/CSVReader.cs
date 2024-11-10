using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class CSVReader 
{
    protected static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    protected static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    protected static char[] TRIM_CHARS = { '\"' };
    protected static string _base_path = "Release_Data/";
    protected static string _design_path = "GameDesign_Data/";
    protected static string _test_path = "Dev_Data/";



    protected static string getBasetPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Resources/";
#elif UNITY_ANDROID
            return Application.persistentDataPath+_filename;
#elif UNITY_IPHONE
            return Application.persistentDataPath+"/"+_filename;
#else
            return Application.dataPath +"/"+_filename;
#endif
    }


    //==========================================================
    //: common function for reading
    //==========================================================
    public static string[] Read_Lines(string file)
    {

        char[] splitter1 = { '/' };
        char[] splitter2 = { '?' };

        TextAsset data = Resources.Load(_base_path + file) as TextAsset;
        if (data == null) return null;
        List<string> fieldnameList = new List<string>();

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);
        return lines;
    }

    public static string[] Make_Header(string header_line)
    {
        var header = Regex.Split(header_line, SPLIT_RE);
        return header;
    }

    public static int Make_Int(string datum)
    {
        if (datum == "")
            return 0;
        int value = int.Parse(datum);
        return value;
    }
    public static float Make_Float(string datum)
    {
        if (datum == "")
            return 0.0f;
        float value = float.Parse(datum);
        return value;
    }
    public static bool Make_Bool(string datum)
    {
        if (datum == "")
            return false;
        if (datum.ToUpper() == "TRUE")
            return true;
        if (datum.ToUpper() == "FALSE")
            return false;

        bool rvalue = false;
        try
        {
            int value = int.Parse(datum);
            rvalue = Convert.ToBoolean(value);
        }
        catch (Exception e)
        {
            return false;
        }
        return rvalue;
    }

    public static int[] Make_intArray(string datum)
    {
        if (string.IsNullOrEmpty(datum))
        {
            return new int[0];
        }

        string[] elements = datum.Split(',');
        List<int> values = new List<int>();

        foreach (var item in elements)
        {
            if (int.TryParse(item.Trim(), out int value))
                values.Add(value);
            else
                values.Add(0); // 변환 실패 시 기본값 추가
        }

        return values.ToArray();
    }

    public static List<int> Make_IntList(string datum)
    {
        return new List<int>(Make_intArray(datum));
    }


    public static float[] Make_FloatArray(string datum)
    {
        if (string.IsNullOrEmpty(datum))
            return new float[0]; // 빈 배열 반환

        string[] elements = datum.Split(',');
        List<float> values = new List<float>();

        foreach (var element in elements)
        {
            if (float.TryParse(element.Trim(), out float value))
                values.Add(value);
            else
                values.Add(0.0f); // 변환 실패 시 기본값 추가
        }

        return values.ToArray();
    }

    public static List<float> Make_FloatList(string datum)
    {
        return new List<float>(Make_FloatArray(datum));
    }

    public static bool[] Make_BoolArray(string datum)
    {
        if (string.IsNullOrEmpty(datum))
            return new bool[0]; // 빈 배열 반환

        string[] elements = datum.Split(',');
        List<bool> values = new List<bool>();

        foreach (var element in elements)
        {
            string trimmed = element.Trim().ToUpper();
            if (trimmed == "TRUE" || trimmed == "1")
                values.Add(true);
            else if (trimmed == "FALSE" || trimmed == "0")
                values.Add(false);
            else
                values.Add(false); // 변환 실패 시 기본값 추가
        }

        return values.ToArray();
    }

    public static List<bool> Make_BoolList(string datum)
    {
        return new List<bool>(Make_BoolArray(datum));
    }


    // 제네릭 메서드를 사용하여 문자열을 특정 enum 타입으로 변환
    public static T ParseEnum<T>(string value) where T : struct, Enum
    {
        if (Enum.TryParse<T>(value, true, out T result))
        {
            return result;
        }

        // 변환 실패 시 Enum의 기본값 반환
        return default(T);
    }









    #region 캐릭터 csv
    public static Dictionary<int, BaseCharacterData> Read_BaseCharacte_data(string file)
    {
        var list = new Dictionary<int, BaseCharacterData>();
        var lines = Read_Lines(file);
        if (lines.Length < 1) return list;
        var header = Make_Header(lines[0]);//헤드라인 먼저 읽기
        for (int i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
            BaseCharacterData tmp_data = new BaseCharacterData();
            tmp_data.Name =Make_Int(values[0]);
            tmp_data.Id = Make_Int(values[1]);
            tmp_data.Discription = Make_Int(values[2]);
            tmp_data.LikeWeatherType = ParseEnum<Utill_Eum.WeatherType>(values[3]);
            tmp_data.MyGenderType = ParseEnum<Utill_Eum.AnimalGenderType>(values[4]);

            list.Add(tmp_data.Id , tmp_data);
        }
        return list;
    }
    #endregion


    #region 유저저장될  Character
    public static Dictionary<int, BaseCharacterData> Read_UserBaseCharacte_data(string file)
    {
        var list = new Dictionary<int, BaseCharacterData>();
        var lines = Read_Lines(file);
        if (lines == null) //기존 파일이 없다면 == 새유저라면
        {
            //데이터를 만들어서 저장
            // 생성한 기본 데이터를 파일에 저장
            CSVWriter.WriteDictionaryToCSV(file+".csv", list, GameDataTable.Instance.headersuserchardata);

            return list; // 기본 데이터 반환
        }



        if (lines.Length < 1) return list;
        var header = Make_Header(lines[0]);//헤드라인 먼저 읽기
        for (int i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
            BaseCharacterData tmp_data = new BaseCharacterData();

            tmp_data.Level = Make_Int(values[0]);
            tmp_data.Exp = Make_Float(values[1]);
            tmp_data.WorkLevel = Make_Int(values[2]);
            tmp_data.TiredRange = Make_Float(values[3]);
            tmp_data.DigRange = Make_Float(values[4]);
            list.Add(tmp_data.Id, tmp_data);
        }
        return list;
    }
    #endregion



    #region 유저로컬 DATA
    public static UserData Read_Userdata(string file)
    {
        var list = new UserData();
        var lines = Read_Lines(file);
        if (lines == null) //기존 파일이 없다면 == 새유저라면
        {
            //데이터를 만들어서 저장
            // 기본 데이터를 생성
            list.User_Id = "NewUser";
            list.Level = -1;
            list.Exp = 0;
            list.UserLastLogin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            list.Version = "1.0";

            // 생성한 기본 데이터를 파일에 저장
           CSVWriter.WriteUserDataToCSV(file + ".csv", list, GameDataTable.Instance.headersuserdata);

            return list; // 기본 데이터 반환
        }


        if (lines.Length < 1) return list;
        var header = Make_Header(lines[0]);//헤드라인 먼저 읽기
        for (int i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
            UserData tmp_data = new UserData();

            tmp_data.User_Id = (values[0]);
            tmp_data.Level = Make_Int(values[1]);
            tmp_data.Exp = Make_Int(values[2]);
            tmp_data.UserLastLogin = (values[3]);
            tmp_data.Version = (values[4]);
            list = tmp_data;
        }
        return list;
    }
    #endregion
}
