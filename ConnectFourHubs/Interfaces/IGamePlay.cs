using ConnectFourHubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourHubs.Interfaces
{
    public interface IGamePlay
    {
        PieceColor DetermineWinner(GameBoard gameBoard);
    }
}
