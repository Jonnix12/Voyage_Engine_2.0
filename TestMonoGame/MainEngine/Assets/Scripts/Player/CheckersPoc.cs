using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class CheckersPoc : GameObject
{
    public override void Start()
    {
        AddComponent<SpriteRenderer,string,int>("ball",0);
        base.Start();
    }
}