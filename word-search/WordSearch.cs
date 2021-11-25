using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    public string[] grid;
    public string[] rev_grid;

    private static string Reverse( string s ) {
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }
    public WordSearch(string grid)
    {
        this.grid=grid.Split("\n");
        this.rev_grid=(
            from s in this.grid 
            select Reverse(s)
        ).ToArray();
    }

    public ((int, int), (int, int))? flipX(((int , int ), (int, int))? pos, int wordLength){
        if(pos==null)
            return null;
        ((int x1, int y1),(int x2,int y2))=pos.Value;
        return ((wordLength-x1+1,y1),(wordLength-x2+1,y1));
    } 
    public ((int, int), (int, int))? findLR(string[] grid, string word) {
        for(int row=0;row<grid.Length;++row) {
            int start=grid[row].IndexOf(word);
            if(start>=0) 
                return ((start+1,row+1),(start+word.Length,row+1));
        }
        return null;
    }

    public ((int, int), (int, int))? findTB(string[] grid, string word) {
        for(int col=0;col<grid[0].Length;++col) {
            for(int row=0;row<=grid.Length-word.Length;++row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row+i][col]!=word[i])
                        goto not_eq;
                }
                return ((col+1,row+1),(col+1,row+word.Length));
                not_eq:    ;            
            }
        }
        return null;
    }

    public ((int, int), (int, int))? findDiagDR(string[] grid, string word) {
        for(int col=0;col<=grid[0].Length-word.Length;++col) {
            for(int row=0;row<=grid.Length-word.Length;++row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row+i][col+i]!=word[i])
                        goto not_eq;
                }
                return ((col+1,row+1),(col+word.Length,row+word.Length));
                not_eq:    ;            
            }
        }
        return null;
    }

    public ((int, int), (int, int))? findDiagDL(string[] grid, string word) {
        for(int col=grid[0].Length-1;col>=word.Length-1;--col) {
            for(int row=0;row<=grid.Length-word.Length;++row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row+i][col-i]!=word[i])
                        goto not_eq;
                }
                return ((col+1,row+1),(col-word.Length+2,row+word.Length));
                not_eq:    ;            
            }
        }
        return null;
    }

    public ((int, int), (int, int))? findDiagUL(string[] grid, string word) {
        for(int col=0;col<=grid[0].Length-word.Length;++col) {
            for(int row=0;row<=grid.Length-word.Length;++row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row+i][col+i]!=word[word.Length-i-1])
                        goto not_eq;
                }
                return ((col+word.Length,row+word.Length),(col+1,row+1));
                not_eq:    ;            
            }
        }
        return null;
    }

    public ((int, int), (int, int))? findDiagUR(string[] grid, string word) {
        for(int col=0;col<=grid[0].Length-word.Length;++col) {
            for(int row=grid.Length-1;row>=word.Length-1;--row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row-i][col+i]!=word[i])
                        goto not_eq;
                }
                return ((col+1,row+1),(col+word.Length,row-word.Length+2));
                not_eq:    ;            
            }
        }
        return null;
    }

    public ((int, int), (int, int))? findBT(string[] grid, string word) {
        for(int col=0;col<grid[0].Length;++col) {
            for(int row=0;row<=grid.Length-word.Length;++row) {
                for(int i=0;i<word.Length;++i) {
                    if(grid[row+i][col]!=word[word.Length-i-1])
                        goto not_eq;
                }
                return ((col+1,row+word.Length),(col+1,row+1));
                not_eq:    ;            
            }
        }
        return null;
    }



    public ((int, int), (int, int))? find(string word) {
        return findLR(grid,word) ?? 
            flipX(findLR(rev_grid,word),grid[0].Length) ??
            findTB(grid,word) ??
            findBT(grid,word) ?? 
            findDiagUR(grid,word) ??
            findDiagUL(grid,word) ??
            findDiagDL(grid,word) ??
            findDiagDR(grid,word)
            ;
    }
    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        Dictionary <string, ((int, int), (int, int))?> found=new Dictionary<string, ((int, int), (int, int))?>();
        foreach(string word in wordsToSearchFor){
            found[word]=find(word);
        }
        return found;
    }

    public static void Main() {
        var grid = 
            "jefblpepre\n" +
            "camdcimgtc\n" +
            "oivokprjsm\n" +
            "pbwasqroua\n" +
            "rixilelhrs\n" +
            "wolcqlirpc\n" +
            "screeaumgr\n" +
            "alxhpburyi\n" +
            "jalaycalmp\n" +
            "clojurermt";

        grid = 
            "jef\n" +
            "cam\n" +
            "oiv" ;

        var sut = new WordSearch(grid);
//        Console.WriteLine(sut.findDiagUL(sut.grid,"vaj")); // works
//        Console.WriteLine(sut.findDiagDR(sut.grid,"jav")); // works
//        Console.WriteLine(sut.findDiagDL(sut.grid,"fao")); // works?
        Console.WriteLine(sut.findDiagUR(sut.grid,"oaf"));
    }
}