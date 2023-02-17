using System.Drawing;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public class Tile 
    {
        public int Row { get; private set; }
        public int Colm { get; private set; }
        
        private Vector2 _size;
        private Vector2 _pos;
        private Color _color;
        private GameObject _tileObject;

        public Tile(int row,int colm,Vector2 pos,Vector2 size,Color color)
        {
            Row = row;
            Colm = colm;
            _pos = pos;
            _size = size;
            _color = color;
        }

        public bool TryAssiagGameObject(GameObject gameObject)
        {
            if(_tileObject != null)
            {
                return false;
            }

            _tileObject = gameObject;

            _tileObject.Transform.Position = _pos;
            _tileObject.Transform.Scale = _size * 0.75f;

            return true;
        }

        public GameObject RemoveTileObject()
        {
            if(_tileObject != null)
            {
                var cache = _tileObject;
                _tileObject = null;

                return cache;
            }

            return null;
        }
    }
}


