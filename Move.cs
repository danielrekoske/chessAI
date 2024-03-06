public class Move
{
    public static bool ExecuteMove(Piece[,] board, int startX, int startY, int endX, int endY)
    {
        if (!IsValidPosition(startX, startY) || board[startX, startY] == null)
            return false;

        Piece piece = board[startX, startY];

        if (!IsValidPosition(endX, endY))
            return false;

        if (!piece.CanMove(board, startX, startY, endX, endY))
            return false;

        board[endX, endY] = piece;
        board[startX, startY] = null;

        return true;
    }

    private static bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
}

