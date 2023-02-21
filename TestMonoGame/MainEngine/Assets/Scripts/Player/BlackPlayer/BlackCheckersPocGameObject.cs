using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class BlackCheckersPocGameObject : GameObject
{
    public BlackCheckersPocGameObject()
    {
        AddComponent<SpriteRenderer,string,int>("Sprites/dog",0);
        AddComponent<Button>();
        AddComponent<CheckersPoc, int>(1);
    }
}