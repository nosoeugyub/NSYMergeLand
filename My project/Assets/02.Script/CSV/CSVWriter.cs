using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class CSVWriter : CSVReader
{
    // Method to save dictionary data to a CSV file
    public static void WriteDictionaryToCSV<T>(string file, Dictionary<int, T> data, List<string> headers) where T : BaseCharacterData
    {
        var filePath = getBasetPath() + _base_path + file;

        StringBuilder csvContent = new StringBuilder();

        // Write the headers to the CSV
        csvContent.AppendLine(string.Join(",", headers));

        // Write each data entry in CSV format
        foreach (var entry in data)
        {
            var line = new List<string>
            {
                entry.Value.Name.ToString(),
                entry.Value.Id.ToString(),
                entry.Value.Discription.ToString(),
                entry.Value.LikeWeatherType.ToString(),
                entry.Value.MyGenderType.ToString()
            };
            csvContent.AppendLine(string.Join(",", line));
        }

        // Write to file
        File.WriteAllText(filePath, csvContent.ToString());
    }

    // Method to save list data to a CSV file
    public static void WriteListToCSV<T>(string file, List<T> data, List<string> headers) where T : BaseCharacterData
    {
        var filePath = getBasetPath() + _base_path + file;

        StringBuilder csvContent = new StringBuilder();

        // Write the headers to the CSV
        csvContent.AppendLine(string.Join(",", headers));

        // Write each data entry in CSV format
        foreach (var item in data)
        {
            var line = new List<string>
            {
                item.Name.ToString(),
                item.Id.ToString(),
                item.Discription.ToString(),
                item.LikeWeatherType.ToString(),
                item.MyGenderType.ToString()
            };
            csvContent.AppendLine(string.Join(",", line));
        }

        // Write to file
        File.WriteAllText(filePath, csvContent.ToString());
    }

    // Method to convert a single BaseCharacterData object to CSV line format
    public static string ConvertToCSVLine(BaseCharacterData data)
    {
        return string.Join(",",
            data.Name,
            data.Id,
            data.Discription,
            data.LikeWeatherType,
            data.MyGenderType);
    }

    // Method to save dictionary data to a CSV file
    public static void WriteUserDataToCSV(string file, UserData userdata, List<string> headers) 
    {
        var filePath = getBasetPath() + _base_path + file;

        StringBuilder csvContent = new StringBuilder();

        // CSV 헤더 추가
        csvContent.AppendLine(string.Join(",", headers));

        // UserData 속성들을 CSV 한 줄로 추가
        var line = new List<string>
    {
        userdata.User_Id,          // 사용자 이름
        userdata.Level.ToString(), // 레벨
        userdata.Exp.ToString(),  // 경험치
        userdata.UserLastLogin,   // 마지막 로그인
        userdata.Version   //버전
    };

        csvContent.AppendLine(string.Join(",", line));

        // 파일에 쓰기
        File.WriteAllText(filePath, csvContent.ToString());
    }

}
