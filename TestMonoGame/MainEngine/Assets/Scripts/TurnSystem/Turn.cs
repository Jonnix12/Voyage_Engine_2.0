using Voage_Engine.Assets.Scripts.Player;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

public class Turn
{
    private Player _player;

    public Player Player => _player;
    
    public Turn(Player player)
    {
        _player = player;
    }
}