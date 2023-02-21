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
        private Vector2 _pos;
        private GameObject[,] _gride;
        private readonly int _column;
        private readonly int _raw;

        public TileMap(int column, int raw, Vector2 tileSize)
        {
            _column = column;
            _raw = raw;
            _gride = new GameObject[column, raw];

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
                    
                    _gride[i, j] = tileGameObject;

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

        public GameObject this[int x, int y]
        {
            get => _gride[x, y];
            set => _gride[x, y] = value;
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            for (int width = 0; _column < width; width++)
            {
                for (int height = 0; _raw < height; height++)
                {
                    yield return _gride[width, height];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<GameObject> GetEnumerator(int row, int col)
        {
            int minWidth = row - 1;
            int minHeight = col - 1;
            int maxWidth = row + 1;
            int maxHeight = col + 1;

            int currentRow = maxWidth;
            int currentCol = maxHeight;

            bool isGoingRight = true;
            bool isGoingDown = false;

            while (currentRow >= minWidth && currentRow <= maxWidth &&
                   currentCol >= minHeight && currentCol <= maxHeight)
            {
                yield return _gride[currentRow, currentCol];

                if (isGoingRight)
                {
                    currentCol++;
                    if (currentCol > maxHeight)
                    {
                        isGoingRight = false;
                        isGoingDown = true;
                        currentCol--;
                        currentRow++;
                    }
                }
                else if (isGoingDown)
                {
                    currentRow++;
                    if (currentRow > maxWidth)
                    {
                        isGoingRight = true;
                        isGoingDown = false;
                        currentRow--;
                        currentCol--;
                    }
                }
            }
        }
    }
}
