using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long firstFactor(long number) {
        for(int i=2; i*i<=number;++i)
            if(number%i==0)
                return i;
        return number;
    }
    public static long[] Factors(long number)
    {
        List<long> factors=new List<long>();
        while(number>1) {
            long fac=firstFactor(number);
            factors.Add(fac);
            number/=fac;
        }
        return factors.ToArray();
    }
}