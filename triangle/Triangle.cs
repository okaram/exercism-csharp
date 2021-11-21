using System;

public static class Triangle
{
    public static bool IsTriangle(double a, double b, double c) 
    {
        return (c>=a && c>=b && a+b>c) ||
            (a>=c && a>=b && b+c>a) ||
            (b>=a && b>=c && a+c>b); 
    }
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return IsTriangle(side1,side2,side3) && side1!=side2 && side2!=side3 && side1!=side3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        return IsTriangle(side1,side2,side3) && (side1==side2 || side2==side3 || side1==side3);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return IsTriangle(side1,side2,side3) && side1==side2 && side2==side3;
    }
}