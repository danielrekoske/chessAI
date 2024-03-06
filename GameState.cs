public class GameState
{
    public Board Board { get; private set; }
    public PieceColor CurrentTurn { get; private set; }
    public List<Move> MoveHistory { get; private set; }

    public GameState()
    {
        Board = new Board();
        CurrentTurn = PieceColor.White;
        MoveHistory = new List<Move>();
    }
}