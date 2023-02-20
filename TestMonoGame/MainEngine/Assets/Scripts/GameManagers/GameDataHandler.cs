using Voyage_Engine.Game_Engine.Objects.Scripts.Players;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameDataHandler
{
    private PlayersHandler _playersHandler;
    
    public GameDataHandler()
    {
        int[,] board = new int[8,8]
        {
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {2,0,2,0,2,0,2,0},
            {0,2,0,2,0,2,0,2},
            {2,0,2,0,2,0,2,0}
        };
        
        _playersHandler = new PlayersHandler();
    }
}