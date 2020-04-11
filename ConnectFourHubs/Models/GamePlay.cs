using ConnectFourHubs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourHubs.Models
{
    public class GamePlay : IGamePlay
    {
        private enum EvaluationDirection
        {
            Up,
            UpRight,
            Right,
            DownRight
        }

        private GameBoard board;
        public PieceColor DetermineWinner(GameBoard gameBoard)
        {
            board = gameBoard;
            PieceColor winnerColor = PieceColor.Blank;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    PieceColor winner = EvaluatePieceForWinner(i, j, EvaluationDirection.Up);
                    if (winner != PieceColor.Blank) { return winner; }

                    winner = EvaluatePieceForWinner(i, j, EvaluationDirection.UpRight);
                    if (winner != PieceColor.Blank) { return winner; }

                    winner = EvaluatePieceForWinner(i, j, EvaluationDirection.Right);
                    if (winner != PieceColor.Blank) { return winner; }

                    winner = EvaluatePieceForWinner(i, j, EvaluationDirection.DownRight);
                    if (winner != PieceColor.Blank) { return winner; }
                }
            }

            return winnerColor;
        }
        private PieceColor EvaluatePieceForWinner(int i, int j, EvaluationDirection dir)
        {
            GamePiece currentPiece = board.Board[i, j];
            if (currentPiece.Color == PieceColor.Blank)
            {
                return PieceColor.Blank;
            }

            int inARow = 1;
            int iNext = i;
            int jNext = j;
            while (inARow < 4)
            {
                switch (dir)
                {
                    case EvaluationDirection.Up:
                        jNext = jNext - 1;
                        break;
                    case EvaluationDirection.UpRight:
                        iNext = iNext + 1;
                        jNext = jNext - 1;
                        break;
                    case EvaluationDirection.Right:
                        iNext = iNext + 1;
                        break;
                    case EvaluationDirection.DownRight:
                        iNext = iNext + 1;
                        jNext = jNext + 1;
                        break;
                }
                if (iNext < 0 || iNext >= 7 || jNext < 0 || jNext >= 6) { break; }
                if (board.Board[iNext, jNext].Color == currentPiece.Color)
                {
                    inARow++;
                }
                else
                {
                    return PieceColor.Blank;
                }
            }
            return inARow >= 4 ? currentPiece.Color : PieceColor.Blank;
        }
    }
}