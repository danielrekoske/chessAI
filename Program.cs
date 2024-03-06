class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();

        List<(int, int, int, int)> legalMoves = GenerateMoves.GetAllPossibleMoves(board.board, PieceColor.White);

        
        if (legalMoves.Count > 0)
        {
            
            var (startX, startY, endX, endY) = legalMoves[0];
            bool moveExecuted = Move.ExecuteMove(board.board, startX, startY, endX, endY);
            if (moveExecuted)
            {
                Console.WriteLine("First move executed successfully!");
                board.PrintBoard();
            }
            else
            {
                Console.WriteLine("Failed to execute the move.");
            }
        }
        else
        {
            Console.WriteLine("No legal moves available.");
        }
    }
}
