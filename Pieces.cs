using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessEngine.ChessPieces;

namespace ChessEngine
{
    namespace ChessPieces
    {
        class Piece
         {
            public string name = "Piece";
            public ChessColor color;
            public ChessBoard board;
            public string imageDirect = "";
            //protected string imageFolder = @"D:\TestVisualFrom\TestFormApp\Simple Chess Game\PieceImages";
            protected string imageFolder = AppDomain.CurrentDomain.BaseDirectory + @"\PieceImages";
            public Piece(ChessColor color, ChessBoard board)
            {
                this.color = color;
                this.board = board;
            }

            public virtual List<PieceMove> GetPieceMoves(Grid pos)
            {
                return new List<PieceMove>();
            }

            public bool InRange(Grid position)
            {
                return (0 <= position.row && position.row < 8) && (0 <= position.column && position.column < 8);
            }

            protected List<Grid> FilterOutOfRange(List<Grid> grids)
            {
                List<Grid> positions = new List<Grid>();
                foreach (Grid grid in grids)
                {
                    if (InRange(grid))
                    {
                        positions.Add(grid);
                    }
                }
                return positions;
            }

            protected List<Grid> GetDirectionalMove(Grid pos, int rowFact, int colFact, int length = 8)
            {
                List<Grid> positions = new List<Grid>();
                pos.row += rowFact;
                pos.column += colFact;
                int count = 0;
                while (InRange(pos))
                {
                    count++;
                    if (board.Board[pos.row, pos.column] != null)
                    {
                        if (board.Board[pos.row, pos.column].color != color)
                        {
                            positions.Add(pos);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    positions.Add(pos);
                    pos.row += rowFact;
                    pos.column += colFact;
                    if(count >= length)
                    {
                        break;
                    }
                }
                return positions;
            }
        }

        class King : Piece
        {

            public King(ChessColor color,ChessBoard board): base(color,board)
            {
                name = "King";
                imageDirect = color == ChessColor.White ? imageFolder + @"\Chess_klt60.png" : imageFolder + @"\Chess_kdt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {
                List<PieceMove> moves = new List<PieceMove>();
                List<Grid> newPositions = GetPattern(pos);
                List<Grid> lockedPositions = new List<Grid>();
                foreach (Piece piece in board.Board)
                {
                    if(piece == null || piece.color == this.color)
                    {
                        continue;
                    }
                    else if(piece.GetType() == typeof(King))
                    {
                        King king = piece as King;
                        foreach( PieceMove move in king.GetRawMoves(board.GetIndex(piece)))
                        {
                            if (!lockedPositions.Contains(move.newPos))
                            {
                                lockedPositions.Add(move.newPos);
                            }
                        }
                        continue;
                    }
                    //Console.WriteLine(piece.ToString() + depth.ToString());
                    List<PieceMove> pieceMoves = piece.GetPieceMoves(board.GetIndex(piece));
                    if (pieceMoves.Count != 0)
                    {
                        foreach(PieceMove move in pieceMoves)
                        {
                            if (!lockedPositions.Contains(move.newPos))
                            {
                                lockedPositions.Add(move.newPos);
                            }
                        }
                    }
                }
                foreach (Grid position in newPositions)
                {
                    if (lockedPositions.Contains(position))
                    {
                        continue;
                    }
                    Piece target = board.Board[position.row, position.column];
                    if (target == null)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Normal));
                    }
                    else if (target.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Eat));
                    }
                }
                return moves;
            }

            public List<PieceMove> GetRawMoves(Grid pos)
            {
                List<PieceMove> moves = new List<PieceMove>();
                List<Grid> newPositions = GetPattern(pos);
                foreach (Grid position in newPositions)
                {
                    Piece target = board.Board[position.row, position.column];
                    if (target == null)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Normal));
                    }
                    else if (target.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Eat));
                    }
                }
                return moves;
            }
            List<Grid> GetPattern(Grid pos)
            {
                List<Grid> unFilteredPositions = new List<Grid> {new Grid(pos.row + 1, pos.column),
                    new Grid(pos.row - 1, pos.column),
                    new Grid(pos.row + 1, pos.column + 1),
                    new Grid(pos.row + 1, pos.column - 1),
                    new Grid(pos.row - 1, pos.column + 1),
                    new Grid(pos.row - 1, pos.column - 1),
                    new Grid(pos.row, pos.column + 1),
                    new Grid(pos.row, pos.column - 1)
                };
                List<Grid> positions = FilterOutOfRange(unFilteredPositions);
                return positions;
            }
        }

        class Queen : Piece
        {
            public Queen(ChessColor color, ChessBoard board) : base(color, board)
            {
                name = "Queen";
                imageDirect = color == ChessColor.White ? imageFolder + @"\Chess_qlt60.png" : imageFolder + @"\Chess_qdt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {
                List<PieceMove> moves = new List<PieceMove>();
                foreach(Grid position in GetPattern(pos))
                {
                    Piece target = board.Board[position.row, position.column];
                    if (target == null)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Normal));
                    }
                    else if(target.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, position, MoveType.Eat));
                    }                  
                }
                return moves;
            }

            List<Grid> GetPattern(Grid pos)
            {
                List<Grid> positions = new List<Grid>();
                positions.AddRange(GetDirectionalMove(pos, 1, 0));
                positions.AddRange(GetDirectionalMove(pos, -1, 0));
                positions.AddRange(GetDirectionalMove(pos, 0, 1));
                positions.AddRange(GetDirectionalMove(pos, 0, -1));
                positions.AddRange(GetDirectionalMove(pos, 1, 1));
                positions.AddRange(GetDirectionalMove(pos, 1, -1));
                positions.AddRange(GetDirectionalMove(pos, -1, 1));
                positions.AddRange(GetDirectionalMove(pos, -1, -1));
                return positions;
            }
        }

        class Bishop : Piece
        {
            public Bishop(ChessColor color, ChessBoard board) : base(color, board)
            {
                name = "Bishop";
                imageDirect = color == ChessColor.White ? imageFolder + @"\Chess_blt60.png" : imageFolder + @"\Chess_bdt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {
                List<Grid> positions = GetPattern(pos);
                List<PieceMove> moves = new List<PieceMove>();
                foreach(Grid grid in positions)
                {
                    Piece target = board.Board[grid.row, grid.column];
                    if (target == null)
                    {
                        moves.Add(new PieceMove(this, pos, grid, MoveType.Normal));
                    }
                    else if(target.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, grid, MoveType.Eat));
                    }
                }
                return moves;
            }

            List<Grid> GetPattern(Grid pos)
            {
                List<Grid> positions = new List<Grid>();
                positions.AddRange(GetDirectionalMove(pos, 1, 1));
                positions.AddRange(GetDirectionalMove(pos, 1, -1));
                positions.AddRange(GetDirectionalMove(pos, -1, 1));
                positions.AddRange(GetDirectionalMove(pos, -1, -1));
                return positions;
            }         
        }

        class Knight : Piece
        {
            public Knight(ChessColor color, ChessBoard board) : base(color, board)
            {
                name = "Knight";
                imageDirect = color == ChessColor.White ? imageFolder + @"\Chess_nlt60.png" : imageFolder + @"\Chess_ndt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {              
                List<PieceMove> moves = new List<PieceMove>();
                List<Grid> positions = FilterOutOfRange(GetMovementPattern(pos));
                //specify movetype and add positions to moves.
                foreach(Grid grid in positions)
                {
                    Piece target = board.Board[grid.row, grid.column];
                    if (target == null)
                    {
                        moves.Add(new PieceMove(this, pos, grid, MoveType.Normal));
                    }
                    else if (target.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, grid, MoveType.Eat));
                    }
                }
                return moves;
            }
         
            List<Grid> GetMovementPattern(Grid pos)
            {
                List<Grid> pattern = new List<Grid>();
                pattern.Add(new Grid(pos.row + 2, pos.column + 1));
                pattern.Add(new Grid(pos.row + 2, pos.column - 1));
                pattern.Add(new Grid(pos.row - 2, pos.column + 1));
                pattern.Add(new Grid(pos.row - 2, pos.column - 1));
                pattern.Add(new Grid(pos.row + 1, pos.column + 2));
                pattern.Add(new Grid(pos.row - 1, pos.column + 2));
                pattern.Add(new Grid(pos.row + 1, pos.column - 2));
                pattern.Add(new Grid(pos.row - 1, pos.column - 2));
                return pattern;
            }
        }

        class Rook : Piece
        {
            public Rook(ChessColor color, ChessBoard board) : base(color, board)
            {
                name = "Rook";
                imageDirect = color == ChessColor.White ? imageFolder + @"\Chess_rlt60.png" : imageFolder + @"\Chess_rdt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {
                List<PieceMove> moves = new List<PieceMove>();
                moves.AddRange(CheckUpwards(pos));
                moves.AddRange(CheckDownwards(pos));
                moves.AddRange(CheckRightwards(pos));
                moves.AddRange(CheckLeftwards(pos));

                //moves.AddRange(CheckDirection(pos,Direction.Up));
                //moves.AddRange(CheckDirection(pos, Direction.Down));
                //moves.AddRange(CheckDirection(pos, Direction.Rigth));
                //moves.AddRange(CheckDirection(pos, Direction.Left));
                return moves;
                
            }
            private List<PieceMove> CheckDownwards(Grid pos)
            {
                int row = pos.row;
                int col = pos.column;
                List<PieceMove> moves = new List<PieceMove>();
                while (row > 0)
                {
                    row--;
                    Piece piece = board.Board[row, col];
                    if (piece == null)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Normal));
                    }
                    else if (piece.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Eat));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                return moves;
            }
          
            private List<PieceMove> CheckUpwards(Grid pos)
            {
                int row = pos.row;
                int col = pos.column;
                List<PieceMove> moves = new List<PieceMove>();
                while (row < 7)
                {
                    row++;
                    Piece piece = board.Board[row, col];
                    if (piece == null)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Normal));
                    }
                    else if (piece.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Eat));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                return moves;
            }

            private List<PieceMove> CheckRightwards(Grid pos)
            {
                int row = pos.row;
                int col = pos.column;
                List<PieceMove> moves = new List<PieceMove>();
                while (col < 7)
                {
                    col++;
                    Piece piece = board.Board[row, col];
                    if (piece == null)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Normal));
                    }
                    else if (piece.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Eat));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                return moves;
            }

            private List<PieceMove> CheckLeftwards(Grid pos)
            {
                int row = pos.row;
                int col = pos.column;
                List<PieceMove> moves = new List<PieceMove>();
                while (col > 0)
                {
                    col--;
                    Piece piece = board.Board[row, col];
                    if (piece == null)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Normal));
                    }
                    else if (piece.color != color)
                    {
                        moves.Add(new PieceMove(this, pos, new Grid(row, col), MoveType.Eat));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                return moves;
            }

            private enum Direction { Up,Down,Rigth,Left};
        }

        class Pawn : Piece
        {
            bool firstMove = true;
            Grid origingPos;

            public Pawn(ChessColor color, ChessBoard board) : base(color, board)
            {
                name = "Pawn";
                imageDirect = color == ChessColor.White ?imageFolder + @"\Chess_plt60.png" : imageFolder +  @"\Chess_pdt60.png";
            }

            public override List<PieceMove> GetPieceMoves(Grid pos)
            {
                List<PieceMove> moves = new List<PieceMove>();
                List<Grid> newPositions = new List<Grid>();
                int color = this.color == ChessColor.White ? -1 : 1;
                //newPositions.Add(new Grid(pos.row + 1 * color, pos.column));
                newPositions = GetDirectionalMove(pos, 1 * color, 0, 1);
                if (firstMove)
                {
                    origingPos = pos;
                    //newPositions.Add(new Grid(pos.row + 2 * color, pos.column));
                    newPositions = GetDirectionalMove(pos, 1 * color, 0, 2);
                }
                else if(pos == origingPos)
                {
                    //newPositions.Add(new Grid(pos.row + 2 * color, pos.column));
                    newPositions = GetDirectionalMove(pos, 1 * color, 0, 2);
                }
                foreach(Grid position in newPositions)
                {
                    if (!InRange(position))
                    {
                        continue;
                    }
                    
                    if (board.Board[position.row,position.column] == null)
                    {
                        if (position.row == 7 || position.row == 0)
                        {
                            moves.Add(new PieceMove(this, pos, position, MoveType.Evolve));
                        }
                        else
                        {
                            moves.Add(new PieceMove(this, pos, position, MoveType.Normal));
                        }
                    }
                }
                List<Grid> eatPositions = new List<Grid>();
                eatPositions.Add(new Grid(pos.row + 1 * color, pos.column + 1));
                eatPositions.Add(new Grid(pos.row + 1 * color, pos.column - 1));
                foreach(Grid position in eatPositions)
                {
                    if (!InRange(position))
                    {
                        continue;
                    }
                    Piece target = board.Board[position.row, position.column];
                    if ( target != null &&  target.color != this.color)
                    {
                        if (position.row == 7 || position.row == 0)
                        {
                            moves.Add(new PieceMove(this, pos, position, MoveType.Evolve));
                        }
                        else
                        {
                            moves.Add(new PieceMove(this, pos, position, MoveType.Eat));
                        }
                    }
                }
                firstMove = false;
                return moves;
            }
        }
    }

    class PieceMove
    {
        public Piece piece;
        public Grid originPos;
        public Grid newPos;
        public MoveType moveType;

        public PieceMove(Piece piece, Grid originPos, Grid newPos, MoveType moveType)
        {
            this.piece = piece;
            this.originPos = originPos;
            this.newPos = newPos;
            this.moveType = moveType;
        }
    }

    public enum MoveType { Normal, Eat, Evolve, Switch };
}