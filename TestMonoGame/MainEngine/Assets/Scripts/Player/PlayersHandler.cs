using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.FactorySystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.Players;

public class PlayersHandler
{
    private Player _whitePlayer;
    private Player _blackPlayer;

    public Player WhitePlayer => _whitePlayer;

    public Player BlackPlayer => _blackPlayer;

    public PlayersHandler()
    {
        _whitePlayer = Factory.Instantiate<WhitePlayerGameObject>().GetComponent<Player>();
        _blackPlayer = Factory.Instantiate<BlackPlayerGameObject>().GetComponent<Player>();
    }
}