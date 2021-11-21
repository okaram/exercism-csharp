using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double dist_sq=x*x+y*y;
        if(dist_sq<=1) 
            return 10;
        else if (dist_sq<=25)
            return 5;
        else if (dist_sq<=100)
            return 1;
        else
            return 0;
    }
}
