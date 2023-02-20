using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

public class BoardUiHandler
{
    private TileMap.TileMap _tileMap;
    
    public BoardUiHandler()
    {
        TileMap.TileMap tileMap = new TileMap.TileMap(8, 8,new Vector2(70,70));
    }

    public void AddRightPlayerPond(params GameObject[] gameObjects)
    {
        int count = 0;
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (_tileMap[i, j].IsHaveValue)
                    return;
                
                _tileMap[i, j].TryAssiagGameObject(gameObjects[count]);
                count++;
            }
        }
    }
    
    public void AddLeftPlayerPond(params GameObject[] gameObjects)
    {
        int count = 0;
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (_tileMap[i, j].IsHaveValue)
                    return;
                
                _tileMap[i, j].TryAssiagGameObject(gameObjects[count]);
                count++;
            }
        }
    }
}