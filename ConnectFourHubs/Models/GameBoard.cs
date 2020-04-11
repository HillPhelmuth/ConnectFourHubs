using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourHubs.Models
{
    public class GameBoard
    {
        public string GroupName { get; set; }
        public GamePiece[,] Board { get; set; }
        public GameBoard()
        {
            Board = new GamePiece[7, 6];
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Board[i, j] = new GamePiece(PieceColor.Blank);
                }
            }
        }
    }
}
