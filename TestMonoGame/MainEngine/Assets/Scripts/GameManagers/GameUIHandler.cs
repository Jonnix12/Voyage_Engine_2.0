using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameUIHandler
{
    private BoardHandler _board;
    
    public GameUIHandler()
    {
        _board = new BoardHandler();
    }
}