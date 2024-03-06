public enum PieceColor
{
    Black,
    White
}

public abstract class Piece
{
    public PieceColor Color { get; }

    public abstract char Symbol { get; }

    public Piece(PieceColor color)
    {
        Color = color;
    }

    public abstract List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY);

    public bool CanMove(Piece[,] board, int startX, int startY, int endX, int endY)
    {
        var legalMoves = GenerateLegalMoves(board, startX, startY);
        return legalMoves.Contains((startX, startY, endX, endY));
    }
}


public class Pawn : Piece
{
    public override char Symbol => 'P';

    public Pawn(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
{
    List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

    int direction = Color == PieceColor.White ? 1 : -1;
    int targetX = startX + direction;
    int targetY = startY;
    if (targetX >= 0 && targetX < 8 && board[targetX, targetY] == null)
    {
        legalMoves.Add((startX, startY, targetX, targetY));

        if ((Color == PieceColor.White && startX == 1) || (Color == PieceColor.Black && startX == 6))
        {
            int doubleMoveTargetX = startX + 2 * direction;
            if (board[doubleMoveTargetX, targetY] == null)
            {
                legalMoves.Add((startX, startY, doubleMoveTargetX, targetY));
            }
        }
    }

    int[] captureDirections = new int[] { -1, 1 };
    foreach (var dy in captureDirections)
    {
        int captureX = targetX;
        int captureY = startY + dy;
        if (captureX >= 0 && captureX < 8 && captureY >= 0 && captureY < 8)
        {
            Piece targetPiece = board[captureX, captureY];
            if (targetPiece != null && targetPiece.Color != this.Color)
            {
                legalMoves.Add((startX, startY, captureX, captureY));
            }
            // Add en passant logic here, you need to verify if en passant is applicable
            // This is a placeholder for en passant, replace with actual conditions
            // bool enPassantCondition = ...;
            // if (enPassantCondition)
            // {
            //     legalMoves.Add((startX, startY, captureX, captureY));
            // }
        }
    }

    return legalMoves;
}
}
public class Rook : Piece
{
    public override char Symbol => 'R';

    public Rook(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
    {
        List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

        for (int i = startX + 1; i < 8; i++)
        {
            if (board[i, startY] == null)
                legalMoves.Add((startX, startY, i, startY));
            else
                break;
        }
        for (int i = startX - 1; i >= 0; i--)
        {
            if (board[i, startY] == null)
                legalMoves.Add((startX, startY, i, startY));
            else
                break;
        }
        for (int j = startY + 1; j < 8; j++)
        {
            if (board[startX, j] == null)
                legalMoves.Add((startX, startY, startX, j));
            else
                break;
        }
        for (int j = startY - 1; j >= 0; j--)
        {
            if (board[startX, j] == null)
                legalMoves.Add((startX, startY, startX, j));
            else
                break;
        }

        return legalMoves;
    }
}

public class Knight : Piece
{
    public override char Symbol => 'N';

    public Knight(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
    {
        List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

        int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

        for (int i = 0; i < 8; i++)
        {
            int nextX = startX + dx[i];
            int nextY = startY + dy[i];
            if (nextX >= 0 && nextX < 8 && nextY >= 0 && nextY < 8 && (board[nextX, nextY] == null || board[nextX, nextY].Color != Color))
            {
                legalMoves.Add((startX, startY, nextX, nextY));
            }
        }

        return legalMoves;
    }
}

public class Bishop : Piece
{
    public override char Symbol => 'B';

    public Bishop(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
    {
        List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

        for (int i = startX + 1, j = startY + 1; i < 8 && j < 8; i++, j++)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX + 1, j = startY - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX - 1, j = startY + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX - 1, j = startY - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }

        return legalMoves;
    }
}

public class Queen : Piece
{
    public override char Symbol => 'Q';

    public Queen(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
    {
        List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

        for (int i = startX + 1; i < 8; i++)
        {
            if (board[i, startY] == null)
                legalMoves.Add((startX, startY, i, startY));
            else
                break;
        }
        for (int i = startX - 1; i >= 0; i--)
        {
            if (board[i, startY] == null)
                legalMoves.Add((startX, startY, i, startY));
            else
                break;
        }
        for (int j = startY + 1; j < 8; j++)
        {
            if (board[startX, j] == null)
                legalMoves.Add((startX, startY, startX, j));
            else
                break;
        }
        for (int j = startY - 1; j >= 0; j--)
        {
            if (board[startX, j] == null)
                legalMoves.Add((startX, startY, startX, j));
            else
                break;
        }

        for (int i = startX + 1, j = startY + 1; i < 8 && j < 8; i++, j++)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX + 1, j = startY - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX - 1, j = startY + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }
        for (int i = startX - 1, j = startY - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == null)
                legalMoves.Add((startX, startY, i, j));
            else
                break;
        }

        return legalMoves;
    }
}

public class King : Piece
{
    public override char Symbol => 'K';

    public King(PieceColor color) : base(color)
    {
    }

    public override List<(int, int, int, int)> GenerateLegalMoves(Piece[,] board, int startX, int startY)
    {
        List<(int, int, int, int)> legalMoves = new List<(int, int, int, int)>();

        int[] dx = { 1, 1, 1, 0, 0, -1, -1, -1 };
        int[] dy = { 1, 0, -1, 1, -1, 1, 0, -1 };

        for (int i = 0; i < 8; i++)
        {
            int nextX = startX + dx[i];
            int nextY = startY + dy[i];
            if (nextX >= 0 && nextX < 8 && nextY >= 0 && nextY < 8 && (board[nextX, nextY] == null || board[nextX, nextY].Color != Color))
            {
                legalMoves.Add((startX, startY, nextX, nextY));
            }
        }

        return legalMoves;
    }
}
