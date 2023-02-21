using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class WhitePlayer : GameObject
{
    public override void Start()
    { 
        var player = AddComponent<Player, string, int>("White Player", 1);
        base.Start();
    }
}