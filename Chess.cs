using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessEngine.ChessPieces;

namespace ChessEngine
{
    class Chess
    {
        ChessBoard chessBoard;
        ChessColor turn = ChessColor.White;
        CheckInfo check = null;
        public ChessColor Turn
        {
            get
            {
                return turn;
            }
        }
        public ChessBoard ChessBoard {
            get
            {
                return chessBoard;
            }       
        }

        public enum GameResult { Draw, Black, White};
        public delegate void GameConclusion(GameResult result);
        public event GameConclusion GameOver;

        public delegate void MovePiece(Grid originPos, Grid newPos);
        public event MovePiece PieceMoved;

        public delegate void PieceEat(Grid position);
        public event PieceEat PieceEaten;

        public delegate void EvolveDelegate(Grid position,ChessColor color);
        public event EvolveDelegate PieceEvolve;
        public event PieceEat PieceEvolved;
        // public delegate void MakeMove(Piece piece, Grid newPos);
        
        class CheckInfo
        {
            public Grid piecePos;
            public ChessColor checkColor;
            public List<Grid> checkPositions;

            public CheckInfo(Grid pos, ChessColor color, List<Grid> positions)
            {
                piecePos = pos;
                checkColor = color;
                checkPositions = positions;
            }
        }

        public Chess()
        {
            chessBoard = new ChessBoard();
        }

        public List<PieceMove> GetMoves(Grid pos)
        {
            Piece piece = chessBoard.Board[pos.row, pos.column];
            if (piece == null || piece.color != turn)
            {
                return new List<PieceMove>();
            }
            List<PieceMove> moves = new List<PieceMove>();
            if (check != null && piece.color == check.checkColor && piece.GetType() != typeof(King))
            {
                foreach(PieceMove move in piece.GetPieceMoves(pos))
                {
                    if (!check.checkPositions.Contains(move.newPos) && move.newPos != check.piecePos)
                    {
                        continue;
                    }
                    else if (TestMove(move))
                    {
                        moves.Add(move);
                    }
                }
                return moves;
            }
            return piece.GetPieceMoves(pos);
        }

        public void MakeMove(PieceMove move)
        {
            ChessColor oppositeColor = move.piece.color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            Piece piece = move.piece;
            if(piece.color != turn)
            {
                return;
            }
            if (move.moveType == MoveType.Evolve)
            {
                ApplyMove(move);
                PieceEvolve?.Invoke(move.newPos,piece.color);
                //send a evolve event and ask for the piece to evolve
            }
            else if (move.moveType == MoveType.Switch)
            {
                //switch with king
            }
            else if(move.moveType == MoveType.Eat)
            {
                Piece deadPiece = chessBoard.Board[move.newPos.row, move.newPos.column];
                chessBoard.AddToGrave(deadPiece);
                PieceEaten?.Invoke(move.newPos);
                ApplyMove(move);
            }
            else if(move.moveType == MoveType.Normal)
            {
                ApplyMove(move);
            }
            check = IsCheckMate(move.newPos);
            ChangeTurn();
            CheckGame();
        }

        void CheckGame()
        {
            if (chessBoard.whiteGrave.Contains(chessBoard.whiteKing))
            {
                GameOver(GameResult.Black);            
            }
            else if (chessBoard.blackGrave.Contains(chessBoard.blackKing))
            {
                GameOver(GameResult.White);
            }
            else if(check != null)
            {
                for (int x = 0; x  < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (GetMoves(new Grid(x,y)).Count != 0)
                        {
                            return;
                        }
                    }
                }
                GameOver(check.checkColor == ChessColor.White ? GameResult.Black : GameResult.White);
            }       
        }

        void CheckMove(Grid pos)
        {
            Piece piece = chessBoard.Board[pos.row, pos.column];
            King king = piece.color != ChessColor.White ? chessBoard.whiteKing : chessBoard.blackKing;
            List<Grid> kingPositions = new List<Grid>();
            king.GetPieceMoves(chessBoard.GetIndex(king)).ForEach(x => kingPositions.Add(x.newPos));
            foreach (PieceMove move in piece.GetPieceMoves(pos))
            {
                if (move.moveType == MoveType.Eat)
                {
                    if(move.newPos == chessBoard.GetIndex(king))
                    {
                        //check
                    }
                    else if (kingPositions.Contains(move.newPos))
                    {
                        //lock position for king
                    }
                }
            }
        }

        CheckInfo IsCheckMate(Grid pos)
        {
            Piece piece = chessBoard.Board[pos.row, pos.column];
            King king = piece.color != ChessColor.White ? chessBoard.whiteKing : chessBoard.blackKing;
            List<Grid> piecePositions = new List<Grid>();
            piece.GetPieceMoves(pos).ForEach(x => piecePositions.Add(x.newPos));
            if (piecePositions.Contains(chessBoard.GetIndex(king)))
            {
                return new CheckInfo(pos, king.color, piecePositions);
            }
            else
            {
                return null;
            }
        }

        bool TestMove(PieceMove move)
        {
            if (move.newPos == check.piecePos)
            {
                return true;
            }
            chessBoard.Board[move.originPos.row, move.originPos.column] = null;
            Piece oldPiece = chessBoard.Board[move.newPos.row, move.newPos.column];        
            chessBoard.Board[move.newPos.row, move.newPos.column] = move.piece;
            CheckInfo checkInfo = IsCheckMate(check.piecePos);
            chessBoard.Board[move.originPos.row, move.originPos.column] = move.piece;
            chessBoard.Board[move.newPos.row, move.newPos.column] = oldPiece;
            if ( checkInfo!= null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void ApplyMove(PieceMove move)
        {
            chessBoard.Board[move.originPos.row, move.originPos.column] = null;
            chessBoard.Board[move.newPos.row, move.newPos.column] = move.piece;
            PieceMoved?.Invoke(move.originPos, move.newPos);
        }

        void ChangeTurn()
        {
            if(turn == ChessColor.White)
            {
                turn = ChessColor.Black;
            }
            else
            {
                turn = ChessColor.White;
            }
        }

        public void EvolvePiece(Grid pos,Piece newPiece)
        {
            if(chessBoard.Board[pos.row, pos.column].GetType() != typeof(Pawn))
            {
                return;
            }
            chessBoard.Board[pos.row, pos.column] = newPiece;
            PieceEvolved?.Invoke(pos);
        }
    }
}
