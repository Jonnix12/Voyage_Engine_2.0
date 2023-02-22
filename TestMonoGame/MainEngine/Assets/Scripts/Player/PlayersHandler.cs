using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.FactorySystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.Players;

public class PlayersHandler
{
    public PlayersHandler()
    {
        WhitePlayer = Factory.Instantiate<WhitePlayerGameObject>().GetComponent<Player>();
        BlackPlayer = Factory.Instantiate<BlackPlayerGameObject>().GetComponent<Player>();
    }

    public Player WhitePlayer { get; }

    public Player BlackPlayer { get; }
}