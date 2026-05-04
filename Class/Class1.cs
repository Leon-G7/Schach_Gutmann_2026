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
                    result += (x + y) % 2 == 0 ? "   " : " # ";
                }
                if (y < 7) result += "|";
            }
            result += "\n";
            if (x < 7) result += "---+---+---+---+---+---+---+---\n";
        }
        return result;
    }

    public void SetFigure(int x, int y, Piece figure)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            _board[x, y] = figure;
        }
    }

    public Piece[,] GetInternalBoard() => _board;
}

public enum PieceColor { White, Black }

public abstract class Piece
{
    public PieceColor Color { get; set; }
    public abstract override string ToString();

    public abstract bool CanMove(int currentX, int currentY, int targetX, int targetY, Piece[,] board);

    protected bool IsPathClear(int currentX, int currentY, int targetX, int targetY, Piece[,] board)
    {
        int stepX = Math.Sign(targetX - currentX);
        int stepY = Math.Sign(targetY - currentY);
        int checkX = currentX + stepX;
        int checkY = currentY + stepY;

        while (checkX != targetX || checkY != targetY)
        {
            if (checkX < 0 || checkX > 7 || checkY < 0 || checkY > 7){
                return false;
                }
            if (board[checkX, checkY] != null){
                return false;
            }
            checkX += stepX;
            checkY += stepY;
        }
        return true;
    }
}

public class King : Piece
{
    public override string ToString() => Color == PieceColor.White ? "K" : "k";

    public override bool CanMove(int currentX, int currentY, int targetX, int targetY, Piece[,] board)
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                int checkX = targetX + x;
                int checkY = targetY + y;

                if (checkX >= 0 && checkX <= 7 && checkY >= 0 && checkY <= 7)
                {
                    var piece = board[checkX, checkY];
                    if (piece is King && piece.Color != this.Color)
                    {
                        return false;
                    }
                }
            }
        }

        if (targetX < 0 || targetX > 7 || targetY < 0 || targetY > 7) return false;

        int distanceX = Math.Abs(targetX - currentX);
        int distanceY = Math.Abs(targetY - currentY);
        
        if (distanceX <= 1 && distanceY <= 1)
        {
            Piece targetPiece = board[targetX, targetY];

            if (targetPiece == null)
            {
                return true;
            }

            if (targetPiece.Color != this.Color && !(targetPiece is King))
            {
                return true;
            }
        }
        
        return false;
    }
}

public class Queen : Piece
{
    public override string ToString() => Color == PieceColor.White ? "Q" : "q";

    public override bool CanMove(int currentX, int currentY, int targetX, int targetY, Piece[,] board)
    {
        if (targetX < 0 || targetX > 7 || targetY < 0 || targetY > 7) return false;

        int distanceX = Math.Abs(targetX - currentX);
        int distanceY = Math.Abs(targetY - currentY);

        bool isStraight = (distanceX == 0 || distanceY == 0);
        bool isDiagonal = (distanceX == distanceY);

        if (isStraight || isDiagonal)
        {
            if (board[targetX, targetY] != null && board[targetX, targetY].Color == this.Color)
                return false;

            return IsPathClear(currentX, currentY, targetX, targetY, board);
        }
        return false;
    }
    
}

public class Rook : Piece
{
    public override string ToString() => Color == PieceColor.White ? "R" : "r";

    public override bool CanMove(int currentX, int currentY, int targetX, int targetY, Piece[,] board)
    {
        if (targetX < 0 || targetX > 7 || targetY < 0 || targetY > 7) return false;

        if (currentX == targetX || currentY == targetY)
        {
            if (board[targetX, targetY] != null && board[targetX, targetY].Color == this.Color)
            {
                return false;
            }

            return IsPathClear(currentX, currentY, targetX, targetY, board);
        }

        return false;
    }
}

public class Bishop : Piece
{
    public override string ToString() => Color == PieceColor.White ? "B" : "b";
    public override bool CanMove(int cX, int cY, int tX, int tY, Piece[,] b) => false;
}

public class Knight : Piece
{
    public override string ToString() => Color == PieceColor.White ? "N" : "n";
    public override bool CanMove(int cX, int cY, int tX, int tY, Piece[,] b) => false;
}

public class Pawn : Piece
{
    public override string ToString() => Color == PieceColor.White ? "P" : "p";

    public override bool CanMove(int currentX, int currentY, int targetX, int targetY, Piece[,] board)
    {
        if (targetX < 0 || targetX > 7 || targetY < 0 || targetY > 7) return false;

        int diffX = targetX - currentX;
        int diffY = targetY - currentY;

        int direction = (Color == PieceColor.White) ? -1 : 1;

        if (diffY == 0) 
        {
            if (diffX == direction)
            {
                return board[targetX, targetY] == null;
            }

            int startRow = (Color == PieceColor.White) ? 6 : 1;
            if (currentX == startRow && diffX == 2 * direction)
            {
                return board[currentX + direction, currentY] == null && board[targetX, targetY] == null;
            }
        }
        else if (Math.Abs(diffY) == 1 && diffX == direction)
        {
            return board[targetX, targetY] != null && board[targetX, targetY].Color != this.Color;
        }

        return false;
    }
}
public class WinCondition { }