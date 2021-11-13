using System;
using System.Collections.Generic;
public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        HashSet<char> letters=new HashSet<char>();
        foreach(char c in word) {
            char cc=Char.ToLower(c);
            if(c==' ' || c=='-')
                continue;
            if(letters.Contains(cc))
                return false;
            letters.Add(cc);
        }
        return true;
    }
}
