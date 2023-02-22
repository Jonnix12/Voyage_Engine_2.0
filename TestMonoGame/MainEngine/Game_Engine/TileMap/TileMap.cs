using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public class TileMap : IEnumerable<GameObject>
    {
        private GameObject[,] _grid;
        
        private readonly int _column;
        private readonly int _raw;

        public TileMap(int column, int raw, Vector2 tileSize)
        {
            _column = column;
            _raw = raw;
            _grid = new GameObject[column, raw];

            float posX = 0;
            float posY = 0;

            Color color = Color.Wheat;

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < raw; j++)
                {
                    var tileGameObject = Factory.Instantiate<TileGameObject>(new Vector2(posX, posY), tileSize);

                    tileGameObject.AddComponent<Tile, int, int>(i,j);
                    tileGameObject.AddComponent<SpriteRenderer, string, int,Color>("Solid_white",0,color);
                    tileGameObject.AddComponent<Button>();
                    
                    _grid[i, j] = tileGameObject;

                    if (j < raw - 1)
                    {
                        color = color == Color.Wheat ? Color.Brown : Color.Wheat;
                    }

                    posY += tileSize.Y;
                }

                posY = 0;
                posX += tileSize.X;
            }
        }

        public GameObject this[int x, int y] => _grid[x, y];

        public IEnumerator<GameObject> GetEnumerator()
        {
            for (int width = 0; width < _column; width++)
            {
                for (int height = 0; height < _raw; height++)
                {
                    yield return _grid[width, height];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
