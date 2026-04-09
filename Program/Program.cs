using ChessGame;

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


        myBoard.SetFigureManual(0, 3, whiteKing);
        myBoard.SetFigureManual(7, 3, blackKing);
        myBoard.SetFigureManual(0, 4, whiteQueen);
        myBoard.SetFigureManual(7, 4, blackQueen);
        myBoard.SetFigureManual(0, 0, whiteRook);
        myBoard.SetFigureManual(0, 7, whiteRook);
        myBoard.SetFigureManual(7, 0, blackRook);
        myBoard.SetFigureManual(7, 7, blackRook);
        myBoard.SetFigureManual(0, 2, whiteBishop);
        myBoard.SetFigureManual(0, 5, whiteBishop);
        myBoard.SetFigureManual(7, 2, blackBishop);
        myBoard.SetFigureManual(7, 5, blackBishop);
        myBoard.SetFigureManual(0, 1, whiteKnight);
        myBoard.SetFigureManual(0, 6, whiteKnight);
        myBoard.SetFigureManual(7, 1, blackKnight);
        myBoard.SetFigureManual(7, 6, blackKnight);
        for (int i = 0; i < 8; i++)
        {
            Pawn pawnblack = new Pawn { Color = PieceColor.Black };
            myBoard.SetFigureManual(6, i, pawnblack);
        }

        for (int i = 0; i < 8; i++)
        {
            Pawn pawnwhite = new Pawn { Color = PieceColor.White };
            myBoard.SetFigureManual(1, i, pawnwhite);
        }


        Console.WriteLine("--- Schach_Gutmann_2026 Testlauf ---\n");
        Console.WriteLine(myBoard.ToString());
        
        Console.WriteLine("\nDrücke eine Taste zum Beenden...");
        Console.ReadKey();
    }
}