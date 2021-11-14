using System;
using System.Text;
public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        String delimiters=" -._";
        StringBuilder ans=new StringBuilder();
        char prev=' ';
        foreach(char c in phrase) {
            if(delimiters.Contains(prev) && !delimiters.Contains(c)) {
                ans.Append(Char.ToUpper(c));
            }
            prev=c;
        }
        return ans.ToString();
    }
}