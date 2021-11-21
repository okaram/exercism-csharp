using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        // => 1 => "United States of America", 55 => "Brazil", 91 => "India"
        return new Dictionary<int, string>(){
            {   1,      "United States of America"},
            {   55,     "Brazil"},
            {   91,     "India"}
        };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        return new Dictionary<int, string>() {
            {countryCode,countryName}
        };
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string CountryName)
    {
        existingDictionary[countryCode]=CountryName;
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.GetValueOrDefault(countryCode,"");
    }
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(existingDictionary.ContainsKey(countryCode))
            existingDictionary[countryCode]=countryName;
        return existingDictionary;

    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longest="";
        foreach(string v in existingDictionary.Values) {
            if(v.Length>longest.Length)
                longest=v;
        }
        return longest;
    }
}
