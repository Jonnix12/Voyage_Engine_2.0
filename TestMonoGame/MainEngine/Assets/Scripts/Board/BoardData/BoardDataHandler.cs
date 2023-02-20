namespace Voyage_Engine.Game_Engine.Objects.Scripts.Board.BoardData;

public class BoardDataHandler
{
    private int[,] _boardGride;

    public BoardDataHandler(int raw, int colum)
    {
        _boardGride = new int[colum, raw];
    }
    
    public BoardDataHandler(int[,] boardGride)
    {
        _boardGride = boardGride;
    }

    public void MovePlayer(int colum, int raw, int newColum, int newRaw)
    {
        
    }
}