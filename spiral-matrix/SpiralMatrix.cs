using System;

public class SpiralMatrix
{
    public static void turnRight(ref int row, ref int col)
    {
        if(row==1 && col==0) {
            row=0;
            col=1;
        } else if (row==0 && col==1) {
            row=-1;
            col=0;
        } else if (row==-1 && col==0) {
            row=0;
            col=-1;
        } else { // row==0, col==-1
            row=1;
            col=0;
        }
    }

    public static bool shouldFlip(int row, int col, int[,] matrirow) {
        int size=matrirow.GetLength(0);
        return row<0 || row>=size || col<0 || col>=size || matrirow[row,col]!=0;
    }

    public static int[,] GetMatrix(int size)
    {
        var matrirow=new int[size,size];
        int drow=1,dcol=0;
        int current=1;
        int row=0,col=0;
        while(!shouldFlip(row,col,matrirow)){
            matrirow[row,col]=current;
            int nrow=row+drow;
            int ncol=col+dcol;
            Console.WriteLine($"{current}\trow={row}, col={col} drow={drow} dcol={dcol}");
            ++current;
            if( shouldFlip(nrow,ncol,matrirow)) {
                turnRight(ref drow, ref dcol);
                nrow=row+drow;
                ncol=col+dcol;
            }
            row=nrow;
            col=ncol;
        }
        return matrirow;
    }

    public static void Main() {
        int drow=1,dcol=0;
        // for(int i=0; i<5; ++i) {
        //     turnRight(ref drow,ref dcol);
        //     Console.WriteLine($"After turning - {drow} {dcol}");
        // }
        GetMatrix(2);
    }
}
