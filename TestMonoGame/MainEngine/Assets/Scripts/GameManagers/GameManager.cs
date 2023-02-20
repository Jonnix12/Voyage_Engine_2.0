namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameManager
{
    private GameUIHandler _uiHandler;
    private GameDataHandler _dataHandler;
    
    public GameManager()
    {
        _dataHandler = new GameDataHandler();
        _uiHandler = new GameUIHandler();
    }
}