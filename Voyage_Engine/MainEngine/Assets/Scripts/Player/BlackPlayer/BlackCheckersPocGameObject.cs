using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class BlackCheckersPocGameObject : GameObject
{
    public BlackCheckersPocGameObject()
    {
        AddComponent<SpriteRenderer, string, int>("Sprites/dog", 1);
        AddComponent<CheckersPoc, int>(2);
    }
}