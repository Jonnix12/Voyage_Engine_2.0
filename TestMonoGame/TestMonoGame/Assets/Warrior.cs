using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Warrior : GameObject
    {
        public override void Start()
        {
            //AddComponent<SpriteRenderer>();
            Debug.Log("Hey form start");
            base.Start();
        }

        public override void Update()
        {
            Debug.Log("Hey form Update");

            base.Update();
        }
    }
}