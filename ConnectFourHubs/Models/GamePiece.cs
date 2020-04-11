using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourHubs.Models
{
    public class GamePiece
    {
        public PieceColor Color;
        public GamePiece(PieceColor color)
        {
            Color = color;
        }
    }
    public enum PieceColor
    {
        Red,
        Yellow,
        Blank
    }
}
