using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voage_Engine.Assets.Scripts.Button;

public class Button : GameObject
{
    private InputObject _input;

    public InputObject Input => _input;
    
    public Button()
    {
        AddComponent<SpriteRenderer, string, int>("Solid_white", 1);
        _input = AddComponent<InputObject>();
    }

    public override void Start()
    {
        Debug.Log("Starty");
        base.Start();
    }
}