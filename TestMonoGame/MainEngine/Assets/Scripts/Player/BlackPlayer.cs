using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class BlackPlayer : GameObject
{
    public override void Start()
    { 
        AddComponent<Player, string, int>("White Player", 2);
        AddComponent<CheckersPoc, int>(2);
        base.Start();
    }
}