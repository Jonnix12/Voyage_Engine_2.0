using Microsoft.Xna.Framework;
using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

public class BoardHandler
{
    private TileMap.TileMap _tileMap;
    
    public BoardHandler()
    {
        TileMap.TileMap tileMap = new TileMap.TileMap(8, 8,new Vector2(70,70));
    }

    public void MovePoc(int colum, int raw, int newColum, int newRaw, int id)
    {
        var tile = _tileMap[colum, raw];
        
        if (!tile.IsHaveValue)
            return;

        var temp = tile.TileObject.GetComponent<CheckersPoc>();
        
        if (temp.Id != id)
            return;

        var gameObject = tile.RemoveTileObject();
        _tileMap[newColum, newRaw].TryAssiagGameObject(gameObject);
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