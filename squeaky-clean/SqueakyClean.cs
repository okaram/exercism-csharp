using System;
using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
    {
        var ans=identifier.Replace(" ","_");
        StringBuilder sb=new StringBuilder();
        for(int i=0;i<ans.Length;++i) {
            char c=ans[i];
            if(c<30) {
                sb.Append("CTRL");
            } else{
                // casing
                if(c=='-'){
                    ++i;
                    sb.Append(Char.ToUpper(ans[i]));
                } else {
                    if ( (!Char.IsLetter(c) && c!='_') || (c>='α' && c<='ω'))
                        continue;
                    else
                        sb.Append(c);
                }
            }
        }      
        ans=sb.ToString();
        return ans;
    }
}
