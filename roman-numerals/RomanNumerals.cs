using System;


public static class RomanNumeralExtension
{
    public static string ToRomanOnes(int value) {
        string[] vals={"","I","II","III","IV","V","VI","VII","VIII","IX"};
        return vals[value];
    }

    public static string ToRomanTens(int value) {
        string[] vals={"","X","XX","XXX","XL","L","LX","LXX","LXXX","XC"};
        return vals[value];
    }

    public static string ToRomanHundreds(int value) {
        string[] vals={"","C","CC","CCC","CD","D","DC","DCC","DCCC","CM"};
        return vals[value];
    }

    public static string ToRoman(this int value)
    {
        string roman="";
        if(value<0)
            return "error";
        while(value>=1000) {
            roman+="M";
            value-=1000;
        }
        roman+=ToRomanHundreds((value%1000)/100);
        roman+=ToRomanTens((value%100)/10);
        roman+=ToRomanOnes(value%10);
        return roman;
    }
}