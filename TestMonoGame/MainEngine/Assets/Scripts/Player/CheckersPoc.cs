using Voyage_Engine.Game_Engine.ComponentSystem;

namespace Voage_Engine.Assets.Scripts.Player;

public class CheckersPoc : Component
{
    private int _id;

    public int Id => _id;

    public CheckersPoc(int id)
    {
        _id = id;
    }
}