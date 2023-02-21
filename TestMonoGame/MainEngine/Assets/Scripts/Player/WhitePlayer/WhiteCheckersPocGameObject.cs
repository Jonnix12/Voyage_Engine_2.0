using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class WhiteCheckersPocGameObject : GameObject
{
    public WhiteCheckersPocGameObject()
    {
        AddComponent<SpriteRenderer,string,int>("Sprites/cat",0);
        AddComponent<CheckersPoc, int>(1);
        //AddComponent<Button>();
    }
}