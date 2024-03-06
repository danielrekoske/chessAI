public class GenerateMoves
{
    public static List<(int startX, int startY, int endX, int endY)> GetAllPossibleMoves(Piece[,] board, PieceColor playerColor)
    {
        List<(int, int, int, int)> possibleMoves = new List<(int, int, int, int)>();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = board[x, y];

                if (piece != null && piece.Color == playerColor)
                {
                    List<(int, int, int, int)> moves = piece.GenerateLegalMoves(board, x, y);

                    possibleMoves.AddRange(moves);
                }
            }
        }

        return possibleMoves;
    }
}
