using System;
using System.Text;
public static class RunLengthEncoding
{
    private static void emitEncoded(StringBuilder accum, char c, int count) {
        if(count==1) {
            accum.Append(c);
        } else {
            accum.Append(count.ToString());
            accum.Append(c);
        }
    }
    public static string Encode(string input)
    {
        if(input=="")
            return "";
        StringBuilder accum=new StringBuilder();
        char prev=input[0];
        int count=1;
        for(int i=0; i<input.Length-1;++i) {
            if(input[i]==input[i+1] && i<input.Length-1) {
                ++count;
            } else { // emit
                emitEncoded(accum,input[i],count);
                count=1;
            }
        }
        emitEncoded(accum,input[input.Length-1],count);
        return accum.ToString();
    }
    private static void emitDecoded(StringBuilder accum, char c, int count) {
        if(count==0) {
            accum.Append(c);
        } else {
            for(int i=0;i<count;++i)
                accum.Append(c);
        }
    }

    public static string Decode(string input)
    {
        StringBuilder accum=new StringBuilder();
        int count=0;
        foreach(char c in input) {
            if(c>='0' && c<='9') {
                count=10*count+c-'0';
            } else {
                emitDecoded(accum,c,count);
                count=0;
            }
        }
        return accum.ToString();
    }
}
