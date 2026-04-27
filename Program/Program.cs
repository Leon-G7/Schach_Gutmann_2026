/*/using ChessGame;

namespace Chess.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        GameField myBoard = new GameField();

        King whiteKing = new King {Color = PieceColor.White};
        King blackKing = new King {Color = PieceColor.Black};
        Queen whiteQueen = new Queen {Color = PieceColor.White};
        Queen blackQueen = new Queen {Color = PieceColor.Black};
        Rook whiteRook = new Rook {Color = PieceColor.White};
        Rook blackRook = new Rook {Color = PieceColor.Black};
        Bishop whiteBishop = new Bishop {Color = PieceColor.White};
        Bishop blackBishop = new Bishop {Color = PieceColor.Black};
        Knight whiteKnight = new Knight {Color = PieceColor.White};
        Knight blackKnight = new Knight {Color = PieceColor.Black};
        Pawn whitePawn = new Pawn {Color = PieceColor.White};
        Pawn blackPawn = new Pawn {Color = PieceColor.Black};


        myBoard.SetFigure(0, 3, whiteKing);
        myBoard.SetFigure(7, 3, blackKing);
        myBoard.SetFigure(0, 4, whiteQueen);
        myBoard.SetFigure(7, 4, blackQueen);
        myBoard.SetFigure(0, 0, whiteRook);
        myBoard.SetFigure(0, 7, whiteRook);
        myBoard.SetFigure(7, 0, blackRook);
        myBoard.SetFigure(7, 7, blackRook);
        myBoard.SetFigure(0, 2, whiteBishop);
        myBoard.SetFigure(0, 5, whiteBishop);
        myBoard.SetFigure(7, 2, blackBishop);
        myBoard.SetFigure(7, 5, blackBishop);
        myBoard.SetFigure(0, 1, whiteKnight);
        myBoard.SetFigure(0, 6, whiteKnight);
        myBoard.SetFigure(7, 1, blackKnight);
        myBoard.SetFigure(7, 6, blackKnight);
        for (int i = 0; i < 8; i++)
        {
            Pawn pawnblack = new Pawn { Color = PieceColor.Black };
            myBoard.SetFigure(6, i, pawnblack);
        }

        for (int i = 0; i < 8; i++)
        {
            Pawn pawnwhite = new Pawn { Color = PieceColor.White };
            myBoard.SetFigure(1, i, pawnwhite);
        }


        Console.WriteLine("--- Schach_Gutmann_2026 Testlauf ---\n");
        Console.WriteLine(myBoard.ToString());
        
        Console.WriteLine("\nDrücke eine Taste zum Beenden...");
        Console.ReadKey();
    }
}
/*/

using ChessGame;

GameField field = new GameField();

Queen whiteQueen = new Queen { Color = PieceColor.White };
field.SetFigure(7, 3, whiteQueen);

field.SetFigure(5, 3, new Pawn { Color = PieceColor.Black });

Console.WriteLine("STARTAUFSTELLUNG:");
Console.WriteLine(field.ToString());

Console.WriteLine("Test 1: Queen versucht illegal über Hindernis zu springen (7,3 -> 4,3)");
TryMove(field, 7, 3, 4, 3);

Console.WriteLine("\nTest 2: Queen schlägt den schwarzen Bauern (7,3 -> 5,3)");
TryMove(field, 7, 3, 5, 3);

Rook whiteRook = new Rook { Color = PieceColor.White };
field.SetFigure(7, 0, whiteRook);
Console.WriteLine("\nTest 3: Turm zieht horizontal (7,0 -> 7,5)");
TryMove(field, 7, 0, 7, 5);

Console.WriteLine("\nENDAUFSTELLUNG:");
Console.WriteLine(field.ToString());


void TryMove(GameField f, int sX, int sY, int tX, int tY)
{
    Piece p = f.GetInternalBoard()[sX, sY];
    if (p != null && p.CanMove(sX, sY, tX, tY, f.GetInternalBoard()))
    {
        f.SetFigure(tX, tY, p);
        f.SetFigure(sX, sY, null);
        Console.WriteLine("SUCCESS: Figur bewegt!");
    }
    else
    {
        Console.WriteLine("FAILED: Zug nicht erlaubt.");
    }
}