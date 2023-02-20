using Microsoft.Xna.Framework.Graphics;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

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

        public override void Update()
        {
            Debug.Log("Hey form Update");

            base.Update();
        }
    }
}