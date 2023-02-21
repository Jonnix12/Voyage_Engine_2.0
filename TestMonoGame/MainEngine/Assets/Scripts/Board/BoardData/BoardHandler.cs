using Microsoft.Xna.Framework;
using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.TileMap;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

public class BoardHandler
{
    private TileMap.TileMap _tileMap;

    public TileMap.TileMap TileMap => _tileMap;

    public BoardHandler()
    {
        _tileMap = new TileMap.TileMap(8, 8,new Vector2(70,70));
    }

    public void MovePoc(int colum, int raw, int newColum, int newRaw, int id)
    {
        var tile = _tileMap[colum, raw].GetComponent<Tile>();
        
        if (!tile.IsHaveValue)
            return;

        var temp = tile.TileObject.GetComponent<CheckersPoc>();
        
        if (temp.Id != id)
            return;

        var gameObject = tile.RemoveTileObject();
        _tileMap[newColum, newRaw].GetComponent<Tile>().TryAssiagGameObject(gameObject);
    }

    public void AddBlackPlayerPoc(params CheckersPoc[] checkersPocs)
    {
        int count = 0;
        int startColumn = 1;
        
        for (int j = 0; j < 3; j++)
        {
            for (int i = startColumn; i < 8; i += 2)
            {

                var tile = _tileMap[i, j].GetComponent<Tile>();

                if (tile.IsHaveValue)
                    return;

                tile.TryAssiagGameObject(checkersPocs[count].GameObject);
                count++;
            }

            startColumn = startColumn == 1 ? 0 : 1;
        }
    }
    
    public void AddWhitePlayerPoc(params CheckersPoc[] checkersPocs)
    {
        int count = 0;
        int startColumn = 0;
        
        for (int j = 5; j < 8; j++)
        {
            for (int i = startColumn; i < 8; i += 2)
            {

                var tile = _tileMap[i, j].GetComponent<Tile>();

                if (tile.IsHaveValue)
                    return;

                tile.TryAssiagGameObject(checkersPocs[count].GameObject);
                count++;
            }

            startColumn = startColumn == 1 ? 0 : 1;
        }
    }
}