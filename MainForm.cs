using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessEngine;
using ChessEngine.ChessPieces;
namespace Simple_Chess_Game
{
    public partial class MainForm : Form
    {
        ChessPanel chessPanel;
        Chess chess;
        DecisionHandler decisionHandler;
        GravePanel gravePanelWhite;
        GravePanel gravePanelBlack;

        public MainForm()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            chess = new Chess();
            chessPanel = new ChessPanel(chess, gameLayoutPanel);
            decisionHandler = new DecisionHandler(chess);
            gravePanelWhite = new GravePanel(sidePanel2,chess,ChessColor.White);
            gravePanelBlack = new GravePanel(sidePanel1, chess, ChessColor.Black);

            chess.GameOver += ShowGameResult;
        }

        void ShowGameResult(Chess.GameResult result)
        {
            DialogResult dialogResult = MessageBox.Show(result.ToString(), "Game Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitGame();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            InitGame();
        }
    }

    class ChessPanel
    {
        ChessSquare[,] squares = new ChessSquare[8, 8];
        Chess chess;
        TableLayoutPanel gameLayoutPanel;
        List<ChessSquare> higlightedSquares = new List<ChessSquare>();
        delegate void ChessSquareClick(Grid Position);
        delegate void ChessMoveClick(PieceMove move);

        class ChessSquare
        {
            public Label label;
            Grid position;
            EventHandler eventHandler;
            EventHandler originEvent;
            Color originColor;
            public ChessColor chessColor;
            public Color focusColor = Color.DarkOliveGreen;
            public Color highlightColor = Color.OliveDrab;
            public Color targetColor = Color.Tomato;

            public ChessSquare(Label label,Grid position, ChessSquareClick click,ChessColor chessColor = ChessColor.White)
            {
                this.label = label;
                this.position = position;
                eventHandler = (sender, e) => click(this.position);
                originEvent = eventHandler;
                originColor = label.BackColor;
                label.Click += eventHandler;
                this.chessColor = chessColor;
            }

            public void Reset()
            {
                label.BackColor = originColor;
                label.BorderStyle = BorderStyle.None;
                label.Click -= eventHandler;
                label.Click += originEvent;
            }

            public void HighlightLabel(ChessMoveClick moveClick,PieceMove move) 
            {
                label.Click -= eventHandler;
                eventHandler = (sender, e) => moveClick(move);
                label.Click += eventHandler;              
                if(label.Image == null)
                {
                    label.BackColor = highlightColor;
                }
                else
                {
                    label.BackColor = targetColor;
                }
            }

            public void Focus()
            {
                label.BackColor = focusColor;
                //label.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        public ChessPanel(Chess chess,TableLayoutPanel panel)
        {
            this.chess = chess;
            chess.PieceMoved += MovePiece;
            chess.PieceEaten += DeletePiece;
            chess.PieceEvolved += UpdatePiece;
            gameLayoutPanel = panel;
            gameLayoutPanel.Controls.Clear();
            DrawBoard();
        }

        void DrawBoard()
        {
            bool isWhite = false;
            for (int x = 0; x < 8; x++)
            {
                isWhite = !isWhite;
                for (int y = 0; y < 8; y++)
                {
                    Label label = new Label();
                    label.Width = gameLayoutPanel.Width / 8;
                    label.Height = gameLayoutPanel.Height / 8;
                    label.BackColor = isWhite ? Color.SandyBrown : Color.Sienna;
                    label.Margin = Padding.Empty;
                    label.Font = new Font("Arial", 13, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    if (chess.ChessBoard.Board[x,y] != null)
                    {
                        //label.Text = chess.ChessBoard.Board[x, y].name;
                        label.ForeColor = chess.ChessBoard.Board[x, y].color == ChessColor.White ? Color.White : Color.Black;
                    }
                    if (chess.ChessBoard.Board[x,y] != null && chess.ChessBoard.Board[x, y].imageDirect != "")
                    {
                        label.Image = Image.FromFile(chess.ChessBoard.Board[x, y].imageDirect);
                    }
                    gameLayoutPanel.Controls.Add(label);
                    ChessColor chessColor = isWhite ? ChessColor.White : ChessColor.Black;
                    ChessSquare square = new ChessSquare(label, new Grid(x, y), OnSquareClick,chessColor);
                    squares[x, y] = square;
                    isWhite = !isWhite;
                }
            }
        }

        void MovePiece(Grid originPos, Grid newPos)
        {
            Console.WriteLine("move");
            ClearHighlighted();
            Image piece = squares[originPos.row, originPos.column].label.Image;
            Color color = squares[originPos.row, originPos.column].label.ForeColor;
            //squares[originPos.row, originPos.column].label.Text = "";
            squares[originPos.row, originPos.column].label.Image = null;
            squares[newPos.row, newPos.column].label.Image = piece;
            squares[newPos.row, newPos.column].label.ForeColor = color;
        }

        void DeletePiece(Grid pos)
        {
            Console.WriteLine("eat");
            //squares[pos.row, pos.column].label.Text = "";
            squares[pos.row, pos.column].label.Image = null;
        }

        void OnSquareClick(Grid position)
        {
            Console.WriteLine("Clicked");
            ClearHighlighted();
            ChessSquare clickedSquare = squares[position.row, position.column];
            Piece clickedPiece = chess.ChessBoard.Board[position.row, position.column];
            if (clickedSquare.label.Image != null && clickedPiece != null && clickedPiece.color == chess.Turn)
            {
                clickedSquare.Focus();
                higlightedSquares.Add(clickedSquare);
            }
            List<PieceMove> moves = chess.GetMoves(position);
            if(moves.Count == 0)
            {
                return;
            }
            foreach(PieceMove move in moves)
            {
                ChessSquare square = squares[move.newPos.row, move.newPos.column];
                square.HighlightLabel(chess.MakeMove, move);
                higlightedSquares.Add(square);
            }
        }

        void ClearHighlighted()
        {
            foreach(ChessSquare square in higlightedSquares)
            {
                square.Reset();
            }
            higlightedSquares.Clear();
        }

        void UpdatePiece(Grid pos)
        {
            squares[pos.row, pos.column].label.Image = Image.FromFile(chess.ChessBoard.Board[pos.row, pos.column].imageDirect);
        }
    }

    class DecisionHandler
    {
        Chess chess;
        Form evolveForm;

        public DecisionHandler(Chess chess)
        {
            this.chess = chess;
            chess.PieceEvolve += ShowEvolvePanel;
            chess.PieceEvolved += ClosePanel;
        }

        void ShowEvolvePanel(Grid pos,ChessColor color)
        {
            Console.WriteLine("evolved");
            evolveForm = new Form();
            List<Control> controls = new List<Control>();
            Button button1 = new Button { Text = "Queen" };
            button1.Click += (sender, e) => chess.EvolvePiece(pos, new Queen(color, chess.ChessBoard));
            controls.Add(button1);
            Button button2 = new Button { Text = "Knight" };
            button2.Click += (sender, e) => chess.EvolvePiece(pos, new Knight(color, chess.ChessBoard));
            controls.Add(button2);
            Button button3 = new Button { Text = "Bishop" };
            button3.Click += (sender, e) => chess.EvolvePiece(pos, new Bishop(color, chess.ChessBoard));
            controls.Add(button3);
            Button button4 = new Button { Text = "Rook" };
            button4.Click += (sender, e) => chess.EvolvePiece(pos, new Rook(color, chess.ChessBoard));
            controls.Add(button4);
            evolveForm.Width = 360;
            evolveForm.Height = 100;
            evolveForm.MaximumSize = evolveForm.Size;
            evolveForm.MinimumSize = evolveForm.Size;
            evolveForm.Text = "Choose a piece";
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = evolveForm.Size;
            evolveForm.Controls.Add(panel);
            foreach (Control control in controls)
            {
                control.Width = panel.Width / 5;
                control.Height = panel.Height / 3;
                panel.Controls.Add(control);
            }
            evolveForm.ShowDialog();
            evolveForm.FormClosed += (sender, e) => chess.EvolvePiece(pos, new Queen(color, chess.ChessBoard));
        }

        void ClosePanel(Grid pos)
        {
            evolveForm.Close();
        }
    }

    class GravePanel
    {
        TableLayoutPanel panel;
        Chess chess;
        ChessColor color;
        List<GraveLabel> labels = new List<GraveLabel>();
        class GraveLabel
        {
            public Button label;
            public Piece piece;
            int count = 1;

            public GraveLabel(Piece piece, Size panelSize, Color color)
            {
                this.piece = piece;
                label = new Button();
                label.Width = panelSize.Width / 3; 
                label.Height = panelSize.Height / 2;
                label.Margin = Padding.Empty;
                label.TextAlign = ContentAlignment.BottomRight;
                label.Text = count + "x";
                label.Font = new Font("Arial", 15, FontStyle.Bold);
                label.Image = Image.FromFile(piece.imageDirect);
                label.FlatStyle = FlatStyle.Flat;
                label.ForeColor = color;
                label.Enabled = false;
            }

            public void Increase()
            {
                count++;
                label.Text = count + "x";
            }
        }

        public GravePanel(TableLayoutPanel panel,Chess chess,ChessColor color)
        {
            this.panel = panel;
            this.chess = chess;
            this.color = color;
            ConstructPanel();
            chess.PieceEaten += AddPieceToGrave;
        }


        void ConstructPanel()
        {
            panel.Controls.Clear();     
        }

        void AddPieceToGrave(Grid pos)
        {
            Piece piece = chess.ChessBoard.Board[pos.row, pos.column];
            if (piece.color != color)
            {
                return;
            }
            foreach(GraveLabel graveLabel in labels)
            { 
                if(graveLabel.piece.GetType() == piece.GetType())
                {
                    graveLabel.Increase();
                    return;
                }
            }
            GraveLabel label = new GraveLabel(piece, panel.Size,panel.BackColor);
            labels.Add(label);
            panel.Controls.Add(label.label);
        }
    }
}
