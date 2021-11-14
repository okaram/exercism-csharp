using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if(balance<0)
            return 3.213f;
        if(balance<1000)
            return 0.5f;
        if(balance<5000)
            return 1.621f;
        else
            return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance*(Decimal)(InterestRate(balance)/100);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance+Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years=0;
        if (balance<0 && targetBalance<0) {
            while(balance>targetBalance) {
                ++years;
                balance=AnnualBalanceUpdate(balance);
            }
        }
        else if (balance>0 && targetBalance>0) {
            while(balance<targetBalance){
                ++years;
                balance=AnnualBalanceUpdate(balance);                
            }
        }
        // if not, either both 0, or different sign, 0 seems like a reasonable answer :)
        return years;
    }

    public static void Main(){
        decimal d=200.75m;
        Console.WriteLine($"d={d}");
        Console.WriteLine($"Interest: {SavingsAccount.Interest(d)}");
        Console.WriteLine($"{SavingsAccount.AnnualBalanceUpdate(d)}");
    }
}
