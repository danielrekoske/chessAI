public class Board
{
    private const int Size = 8;
    public Piece[,] board;

    public Board()
    {
        board = new Piece[Size, Size];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            board[1, i] = new Pawn(PieceColor.Black);
            board[6, i] = new Pawn(PieceColor.White);
        }

        board[0, 0] = new Rook(PieceColor.Black);
        board[0, 1] = new Knight(PieceColor.Black);
        board[0, 2] = new Bishop(PieceColor.Black);
        board[0, 3] = new Queen(PieceColor.Black);
        board[0, 4] = new King(PieceColor.Black);
        board[0, 5] = new Bishop(PieceColor.Black);
        board[0, 6] = new Knight(PieceColor.Black);
        board[0, 7] = new Rook(PieceColor.Black);

        board[7, 0] = new Rook(PieceColor.White);
        board[7, 1] = new Knight(PieceColor.White);
        board[7, 2] = new Bishop(PieceColor.White);
        board[7, 3] = new Queen(PieceColor.White);
        board[7, 4] = new King(PieceColor.White);
        board[7, 5] = new Bishop(PieceColor.White);
        board[7, 6] = new Knight(PieceColor.White);
        board[7, 7] = new Rook(PieceColor.White);
    }

    public void PrintBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] == null)
                    Console.Write("- "); // Empty square
                else
                    Console.Write(board[i, j].Symbol + " "); // Piece symbol
            }
            Console.WriteLine();
        }
    }

    public Piece[,] GetBoard()
    {
        return board;
    }
}
