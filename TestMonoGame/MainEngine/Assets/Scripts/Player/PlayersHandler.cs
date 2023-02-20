namespace Voyage_Engine.Game_Engine.Objects.Scripts.Players;

public class PlayersHandler
{
    private Player _blackPlayer;
    private Player _whitePlayer;

    public Player BlackPlayer => _blackPlayer;

    public Player WhitePlayer => _whitePlayer;

    public PlayersHandler()
    {
        _blackPlayer = new Player(1, "Black");
        _whitePlayer = new Player(2, "White");
    }
}