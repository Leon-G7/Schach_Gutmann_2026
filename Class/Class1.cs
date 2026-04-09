using System.Security.Cryptography.X509Certificates;

namespace ChessGame;

public class GameField
{
    private readonly Piece[,] _board = new Piece[8, 8];

    public override string ToString()
    {
        string result = "";

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = _board[x, y];

                if (piece != null)
                {
                    result += $" {piece} ";
                }
                else
                {
                    if ((x + y) % 2 == 0)
                    {
                        result += "   ";
                    }
                    else
                    {
                        result += " # ";
                    }
                }

                if (y < 7) result += "|";
            }

            result += "\n";

            if (x < 7)
            {
                result += "---+---+---+---+---+---+---+---\n";
            }
        }
        return result;
    }

    public void SetFigureManual(int x, int y, Piece figure)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            _board[x, y] = figure;
        }
    }
}

public class SetFigure
{
    // Hier kommen später Methoden rein wie:
    // public void Place(GameField field, int x, int y, Piece piece)
}

public enum PieceColor
{
    White,
    Black
}

public abstract class Piece
{
    public PieceColor Color { get; set; }

    public abstract override string ToString();
}

public class King : Piece
{
    public override string ToString() => Color == PieceColor.White ? "K" : "k";

    public 
}

public class Queen : Piece
{
    public override string ToString() => Color == PieceColor.White ? "Q" : "q";
}

public class Rook : Piece
{
    public override string ToString() => Color == PieceColor.White ? "R" : "r";
}

public class Bishop : Piece
{
    public override string ToString() => Color == PieceColor.White ? "B" : "b";
}

public class Knight : Piece
{
    public override string ToString() => Color == PieceColor.White ? "N" : "n";
}

public class Pawn : Piece
{
    public override string ToString() => Color == PieceColor.White ? "P" : "p";
}

public class WinCondition
{
}