using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public class TileMap : IEnumerable<Tile>
    {
        private Vector2 _pos;
        private Tile[,] _gride;
        private int width;
        private int height;

        public TileMap(int width, int height, Vector2 tileSize)
        {
            this.width = width;
            this.height = height;
            _gride = new Tile[width, height];

            float posX = 0;
            float posY = 0;

            Color color = Color.Wheat;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _gride[i, j] = new Tile(i, j, new Vector2(posX, posY), tileSize, color);

                    if (j < height - 1)
                    {
                        color = color == Color.Wheat ? Color.Brown : Color.Wheat;
                    }

                    posY += tileSize.Y;
                }

                posY = 0;
                posX += tileSize.X;
            }
        }

        public Tile this[int x, int y]
        {
            get => _gride[x, y];
            set => _gride[x, y] = value;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            for (int width = 0; this.width < width; width++)
            {
                for (int height = 0; this.height < height; height++)
                {
                    yield return _gride[width, height];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tile> GetEnumerator(int row, int col)
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
