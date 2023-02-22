using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class BlackPlayerGameObject : GameObject
{
    public BlackPlayerGameObject()
    {
        AddComponent<Player, string, int>("Black Player", 2);
    }
}