using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.FactorySystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.Players;

public class PlayersHandler
{
    private Player _blackBlackPlayer;
    private Player _whiteBlackPlayer;

    public Player BlackBlackPlayer => _blackBlackPlayer;

    public Player WhiteBlackPlayer => _whiteBlackPlayer;

    public PlayersHandler()
    {
        _whiteBlackPlayer = Factory.Instantiate<WhitePlayer>().GetComponent<Player>();
        _blackBlackPlayer = Factory.Instantiate<BlackPlayer>().GetComponent<Player>();
    }
}