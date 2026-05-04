using System.Xml;
using ChessGame;

namespace Tests;

public class ChessGameTests
{
    [Fact]
    public void Test_Set_Figure_With_White()
    {
        GameField game = new GameField();
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(1, 1, whitePawn);

        var board = game.GetInternalBoard();
        Piece figureAtPosition = board[1, 1];

        Assert.NotNull(figureAtPosition);
        Assert.Equal(whitePawn, figureAtPosition);
        Assert.Equal(PieceColor.White, figureAtPosition.Color);
    }

    [Fact]
    public void Test_Set_Figure_White_To_Null()
    {
        GameField game = new GameField();
        game.SetFigure(1, 1, new Pawn { Color = PieceColor.White });

        game.SetFigure(1, 1, null);

        var board = game.GetInternalBoard();
        Piece figureAtPosition = board[1, 1];

        Assert.Null(figureAtPosition);
    }

    [Fact]
    public void Test_Set_Figure_Black_To_Null()
    {
        GameField game = new GameField();
        game.SetFigure(1, 1, new Pawn { Color = PieceColor.Black });

        game.SetFigure(1, 1, null);

        var board = game.GetInternalBoard();
        Piece figureAtPosition = board[1, 1];

        Assert.Null(figureAtPosition);
    }

    [Fact]
    public void Test_Set_Figure_With_Black(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(1, 1, blackPawn);

        var board = game.GetInternalBoard();
        Piece figureAtPosition = board[1, 1];

        Assert.NotNull(figureAtPosition);
        Assert.Equal(blackPawn, figureAtPosition);
        Assert.Equal(PieceColor.Black, figureAtPosition.Color);
    }

    [Fact]
    public void Test_If_Field_Is_Empty_When_It_Should(){
        GameField game = new GameField();

        var board = game.GetInternalBoard();
        Piece figureAtPosition = board[1, 1];

        Assert.Null(figureAtPosition);
    }

    [Fact]
    public void Test_Board_Rendering(){
        GameField game = new GameField();

        string output = game.ToString();

        Assert.Contains("|", output);
        Assert.Contains("---", output);
    }

    [Fact]
    public void Test_Game_Board_Dimensions(){
        GameField game = new GameField();

        var board = game.GetInternalBoard();

        Assert.Equal(8, board.GetLength(0)); 
        Assert.Equal(8, board.GetLength(1));
    }

    [Fact]
    public void Test_Board_Is_Initially_Empty()
    {
        GameField game = new GameField();
        var board = game.GetInternalBoard();

        Assert.Null(board[0, 0]);
        Assert.Null(board[7, 7]);
        Assert.Null(board[4, 3]);
    }

    [Fact]
    public void Test_If_Every_Field_Is_Empty(){
        GameField game = new GameField();

        var board = game.GetInternalBoard();

        for(int x = 0; x < 8; x++){
            for(int y = 0; y < 8; y++){
                Assert.Null(board[x, y]);
            }
        }
    }
}
public class QueenTests{
    [Fact]
    public void Test_If_Queen_Can_Move_Forward(){
        GameField game = new GameField();
        Queen blackQueen = new Queen { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackQueen);

        bool canMove = blackQueen.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Queen_Can_Move_Backwards(){
        GameField game = new GameField();
        Queen blackQueen = new Queen { Color = PieceColor.Black };

        game.SetFigure(1, 0, blackQueen);

        bool canMove = blackQueen.CanMove(1, 0, 0, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Queen_Can_Move_To_Side(){
        GameField game = new GameField();
        Queen blackQueen = new Queen { Color = PieceColor.Black };

        game.SetFigure(1, 0, blackQueen);

        bool canMove = blackQueen.CanMove(1, 0, 1, 1, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Queen_Can_Move_Diagonal(){
        GameField game = new GameField();
        Queen blackQueen = new Queen { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackQueen);

        bool canMove = blackQueen.CanMove(0, 0, 1, 1, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_Queen_Can_Capture_Enemy(){
        GameField game = new GameField();
        Queen whiteQueen = new Queen { Color = PieceColor.White };
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(0, 0, whiteQueen);
        game.SetFigure(0, 5, blackPawn);

        bool canCapture = whiteQueen.CanMove(0, 0, 0, 5, game.GetInternalBoard());

        Assert.True(canCapture);
    }

    [Fact]
    public void Test_If_Queen_Can_Jump_Over_Figures(){
        GameField game = new GameField();
        Queen whiteQueen = new Queen { Color = PieceColor.White };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(0, 0, whiteQueen);
        game.SetFigure(0, 5, whitePawn);

        bool canJump = whiteQueen.CanMove(0, 0, 0, 6, game.GetInternalBoard());

        Assert.False(canJump);
    }

    [Fact]
    public void Test_If_Queen_Can_Capture_Own_Figure(){
        GameField game = new GameField();
        Queen whiteQueen = new Queen { Color = PieceColor.White };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(0, 0, whiteQueen);
        game.SetFigure(0, 5, whitePawn);

        bool canMove = whiteQueen.CanMove(0, 0, 0, 5, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_Queen_Can_Jump_Out_Of_The_Field(){
        GameField game = new GameField();
        Queen whiteQueen = new Queen { Color = PieceColor.White };

        game.SetFigure(0, 0, whiteQueen);

        bool canMove = whiteQueen.CanMove(0, 0, 9, 9, game.GetInternalBoard());

        Assert.False(canMove);
    }
}

public class PawnTests{
    [Fact]
    public void Test_If_Pawn_Can_Move(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackPawn);

        bool canMove = blackPawn.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Move_Backwards(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(3, 3, blackPawn);

        bool canMove = blackPawn.CanMove(3, 3, 3, 2, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Move_2_Fields_When_On_Start_Position(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(1, 0, blackPawn);

        bool canMove = blackPawn.CanMove(1, 0, 3, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Move_2_Fields_When_Not_On_Start_Position(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(2, 0, blackPawn);

        bool canMove = blackPawn.CanMove(2, 0, 4, 0, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Move_Diagonal(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackPawn);

        bool canMove = blackPawn.CanMove(0, 0, 1, 1, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Jump_Out_Of_The_Field(){
        GameField game = new GameField();
        Queen whiteQueen = new Queen { Color = PieceColor.White };

        game.SetFigure(0, 0, whiteQueen);

        bool canMove = whiteQueen.CanMove(0, 0, 9, 9, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_Pawn_Can_Capture_Forward(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.White };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(0, 0, blackPawn);
        game.SetFigure(1, 0, whitePawn);

        bool canCapture = blackPawn.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.False(canCapture);
    }

    [Fact]
    public void Test_If_Pawn_Can_Capture_Diagonal(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(0, 0, blackPawn);
        game.SetFigure(1, 1, whitePawn);

        bool canCapture = blackPawn.CanMove(0, 0, 1, 1, game.GetInternalBoard());

        Assert.True(canCapture);
    }

    [Fact]
    public void Test_If_Pawn_Can_Capture_Diagonal_Backwards(){
        GameField game = new GameField();
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(1, 1, blackPawn);
        game.SetFigure(0, 0, whitePawn);

        bool canCapture = blackPawn.CanMove(1, 1, 0, 0, game.GetInternalBoard());

        Assert.False(canCapture);
    }
}

public class KingTests{
    [Fact]
    public void Test_If_King_Can_Move(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackKing);

        bool canMove = blackKing.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_King_Can_Move_2_Fields(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackKing);

        bool canMove = blackKing.CanMove(0, 0, 2, 0, game.GetInternalBoard());

        Assert.False(canMove);
    }

    [Fact]
    public void Test_If_King_Can_Capture_Enemie(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };
        Pawn whitePawn = new Pawn { Color = PieceColor.White };

        game.SetFigure(0, 0, blackKing);
        game.SetFigure(1, 0, whitePawn);

        bool canCapture = blackKing.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.True(canCapture);
    }

    [Fact]
    public void Test_If_King_Can_Capture_Own_Figure(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };
        Pawn blackPawn = new Pawn { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackKing);
        game.SetFigure(1, 0, blackPawn);

        bool canCapture = blackKing.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.False(canCapture);
    }

    [Fact]

    public void Test_If_King_Can_Capture_Other_King(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };
        King whiteKing = new King { Color = PieceColor.White };

        game.SetFigure(0, 0, blackKing);
        game.SetFigure(1, 0, whiteKing);

        bool canCapture = blackKing.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.False(canCapture);
    }

    [Fact]
    public void Test_If_King_Can_Move_Next_To_Other_King(){
        GameField game = new GameField();
        King blackKing = new King { Color = PieceColor.Black };
        King whiteKing = new King { Color = PieceColor.White };

        game.SetFigure(0, 0, blackKing);
        game.SetFigure(2, 0, whiteKing);

        bool canMove = blackKing.CanMove(0, 0, 1, 0, game.GetInternalBoard());

        Assert.False(canMove);
    }
}

public class RookTests{
    [Fact]
    public void Test_If_Rook_Can_Move(){
        GameField game = new GameField();
        Rook blackRook = new Rook { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackRook);

        bool canMove = blackRook.CanMove(0, 0, 5, 0, game.GetInternalBoard());

        Assert.True(canMove);
    }

    [Fact]
    public void Test_If_Rook_Can_Move_Diagonal(){
        GameField game = new GameField();
        Rook blackRook = new Rook { Color = PieceColor.Black };

        game.SetFigure(0, 0, blackRook);

        bool canMove = blackRook.CanMove(0, 0, 1, 1, game.GetInternalBoard());

        Assert.False(canMove);
    }
}
