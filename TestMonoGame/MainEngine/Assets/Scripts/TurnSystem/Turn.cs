using Voage_Engine.Assets.Scripts.Player;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

public class Turn
{
    public Turn(Player player)
    {
        Player = player;
    }

    public Player Player { get; }
}