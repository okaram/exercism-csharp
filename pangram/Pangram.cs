using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        bool[] letters=new bool[26];
        foreach(char c in input){
            char cc=Char.ToLower(c);
            if(cc>='a' && cc<='z')
                letters[cc-'a']=true;
        }
        // now check they are all there
        foreach(bool b in letters){
            if(!b)
                return false;
        }
        return true;
    }
}
