using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameUIHandler
{
    private BoardUiHandler _boardUi;
    
    public GameUIHandler()
    {
        _boardUi = new BoardUiHandler();
    }
}