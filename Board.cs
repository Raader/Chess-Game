using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessEngine.ChessPieces;
namespace ChessEngine
{
    class ChessBoard
    {
        Piece[,] board = new Piece[8, 8];
        public List<Piece> whiteGrave = new List<Piece>();
        public List<Piece> blackGrave = new List<Piece>();

        public Piece[,] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }
        public King whiteKing;
        public King blackKing;

        public ChessBoard()
        {
            //init Pawns
            for(int i = 0; i < 8; i++)
            {
                board[6, i] = new Pawn(ChessColor.White, this);
                board[1, i] = new Pawn(ChessColor.Black, this);
            }
            //init Rooks
            board[0, 0] = new Rook(ChessColor.Black, this);
            board[0, 7] = new Rook(ChessColor.Black, this);
            board[7, 0] = new Rook(ChessColor.White, this);
            board[7, 7] = new Rook(ChessColor.White, this);
            //init Kings
            board[0, 4] = new King(ChessColor.Black,this);
            blackKing = board[0, 4] as King;
            board[7, 4] = new King(ChessColor.White,this);
            whiteKing = board[7, 4] as King;
            //init Queens
            board[0, 3] = new Queen(ChessColor.Black, this);
            board[7, 3] = new Queen(ChessColor.White, this);
            //init Bishops
            board[0, 2] = new Bishop(ChessColor.Black, this);
            board[0, 5] = new Bishop(ChessColor.Black, this);
            board[7, 2] = new Bishop(ChessColor.White, this);
            board[7, 5] = new Bishop(ChessColor.White, this);
            //init Knights
            board[0, 1] = new Knight(ChessColor.Black, this);
            board[0, 6] = new Knight(ChessColor.Black, this);
            board[7, 1] = new Knight(ChessColor.White, this);
            board[7, 6] = new Knight(ChessColor.White, this);
        }

        public Grid GetIndex(Piece piece)
        {
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0;  y < 8; y++)
                {
                    if(board[x,y] == piece)
                    {
                        return new Grid(x, y);                     
                    }
                }
            }
            return new Grid();
        }

        public void AddToGrave(Piece piece)
        {
            if(piece.color == ChessColor.White)
            {
                whiteGrave.Add(piece);
            }
            else
            {
                blackGrave.Add(piece);
            }
        }
    }

    struct Grid
    {
        public int row;
        public int column;

        public Grid(int row,int column)
        {
            this.row = row;
            this.column = column;
        }

        public static bool operator !=(Grid a, Grid b)
        {
            if (a.row != b.row || a.column != b.column)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Grid a, Grid b)
        {
            if(a.row == b.row && a.column == b.column)
            {
                return true;
            }
            return false;
        }

    }

    public enum ChessColor { None, White, Black};
}
