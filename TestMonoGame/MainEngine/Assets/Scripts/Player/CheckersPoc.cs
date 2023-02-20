using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class CheckersPoc : GameObject
{
    public override void Start()
    {
        var spriteRender = AddComponent<SpriteRenderer,string,int>("ball",0);
        AddComponent<Button,SpriteRenderer>(spriteRender);
        base.Start();
    }
}