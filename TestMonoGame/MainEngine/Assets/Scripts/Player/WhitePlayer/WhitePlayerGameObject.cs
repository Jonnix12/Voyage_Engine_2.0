using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class WhitePlayerGameObject : GameObject
{
    public WhitePlayerGameObject()
    {
        AddComponent<Player, string, int>("White Player", 1);

    }
}