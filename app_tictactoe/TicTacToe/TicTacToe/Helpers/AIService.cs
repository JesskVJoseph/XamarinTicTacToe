using System;

namespace TicTacToe
{
    public class SimpleAI
    {

    // This will return random number from the remaning avaliable postions
     public  int FindBestMove(string[,] board)
        {
            int[] remaingPostions = new int[9];
            int emptyCount = 0;
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(board[i, j]))
                    {
                        remaingPostions[emptyCount] = GetPostion(i,j);
                        emptyCount++;
                    }
                }
            }
            return remaingPostions[rnd.Next(0, emptyCount - 1)];
        }

      int  GetPostion(int row, int col)
        { 
             if (row == 0 && col == 0)
                return 0; 
             else if (row == 0 && col == 1)
                return 1;
             else if (row == 0 && col == 2)
                return 2;
             else if (row == 1 && col == 0)
                return 3;
             else if (row == 1 && col == 1)
                return 4;
             else if (row == 1 && col == 2)
                return 5;
             else if (row == 2 && col == 0)
                return 6;
             else if (row == 2 && col == 1)
                return 7;
             else
                return 8;
        }
    }
}

