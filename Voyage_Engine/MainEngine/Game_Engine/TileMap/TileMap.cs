using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voyage_Engine.Game_Engine.TileMap;

public class TileMap : IEnumerable<GameObject>
{
    private readonly int _column;
    private readonly int _raw;
    private readonly GameObject[,] _grid;
    
    public GameObject this[int x, int y] => _grid[x, y];

    public TileMap(int column, int raw, Vector2 tileSize)
    {
        _column = column;
        _raw = raw;
        _grid = new GameObject[column, raw];

        float posX = 0;
        float posY = 0;

        var color = Color.Wheat;

        for (var i = 0; i < column; i++)
        {
            for (var j = 0; j < raw; j++)
            {
                var tileGameObject = Factory.Instantiate<TileGameObject>(new Vector2(posX, posY), tileSize);

                tileGameObject.AddComponent<Tile, int, int>(i, j);
                tileGameObject.AddComponent<SpriteRenderer, string, int, Color>("Solid_white", 0, color);
                tileGameObject.AddComponent<InputObject>();

                _grid[i, j] = tileGameObject;

                if (j < raw - 1) color = color == Color.Wheat ? Color.Brown : Color.Wheat;

                posY += tileSize.Y;
            }

            posY = 0;
            posX += tileSize.X;
        }
    }

    public IEnumerator<GameObject> GetEnumerator()
    {
        for (var width = 0; width < _column; width++)
        for (var height = 0; height < _raw; height++)
            yield return _grid[width, height];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}