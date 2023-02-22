using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameManager
{
    public static int LastWin;
    
    private GameDataHandler _dataHandler;

    public GameManager()
    {
        _dataHandler = Factory.Instantiate<GameDataHandler>();
    }

    public static void EndGame(int winIndex)
    {
        if (winIndex != -1)
        {
            LastWin = winIndex;
            SceneManager.NextScene();
        }
    }
}