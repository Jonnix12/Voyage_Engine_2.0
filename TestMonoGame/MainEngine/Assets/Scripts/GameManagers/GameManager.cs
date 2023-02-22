using Voyage_Engine.Game_Engine.FactorySystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameManager
{
    private GameDataHandler _dataHandler;

    public GameManager()
    {
        _dataHandler = (GameDataHandler) Factory.Instantiate<GameDataHandler>();
    }
}