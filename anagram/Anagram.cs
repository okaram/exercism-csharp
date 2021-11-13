using System;
using System.Collections.Generic;
public class Anagram
{
    Dictionary<char,int> letterFreq;
    string baseWord;
    public Anagram(string baseWord)
    {
        this.baseWord=baseWord;
        this.letterFreq=toFreq(baseWord);
    }

    private static Dictionary<char,int> toFreq(string word) 
    {
        var freqs=new Dictionary<char,int>();
        foreach(char c in word) {
            char cc=Char.ToLower(c);
            if(freqs.ContainsKey(cc)) 
                ++freqs[cc];
            else
                freqs.Add(cc,1);
        }
        return freqs;
    }   

    bool equalDicts(Dictionary<char,int> d1, Dictionary<char,int> d2) {
        if(d1.Count!=d2.Count)
            return false;
        int value=0;
        foreach(var kv in d1) {
            if(!d2.TryGetValue(kv.Key,out value))
                return false;
            if(kv.Value!=value)
                return false;
        }
        return true;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var matches=new HashSet<string>();
        foreach(string s in potentialMatches){
            if(s.ToLower()!=baseWord.ToLower() && equalDicts(toFreq(s),letterFreq))
                matches.Add(s);
        }
        return new List<string>(matches).ToArray();
    }
}