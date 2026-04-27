using System.Drawing;
using System.IO.Pipelines;
using ChessGame;

namespace Tests;

public class ChessGame
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
