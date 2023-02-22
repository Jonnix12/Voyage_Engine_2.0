using Voyage_Engine.Game_Engine.ComponentSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class CheckersPoc : Component
{
    public CheckersPoc(int id)
    {
        Id = id;
    }

    public int Id { get; }
}