using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string separator)
    {
        int idx=str.IndexOf(separator);
        return str.Substring(idx+separator.Length);
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string sep1, string sep2)
    {
        int idx1=str.IndexOf(sep1)+sep1.Length;
        int idx2=str.IndexOf(sep2);
        return str.Substring(idx1, idx2-idx1);
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[","]");
    }
}