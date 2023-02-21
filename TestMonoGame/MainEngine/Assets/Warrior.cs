using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Warrior : GameObject
    {
        public override void Start()
        {
            SpriteRenderer spriteRenderer = AddComponent<SpriteRenderer,string,int>("ball",0);
            AddComponent<Button, SpriteRenderer>(spriteRenderer);
            Debug.Log("Hey form start");
            base.Start();
        }
    }
}