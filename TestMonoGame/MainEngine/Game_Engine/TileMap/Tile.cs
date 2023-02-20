using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public class Tile : RenderObject
    {
        protected override string Path { get; }
        
        private Vector2 _size;
        private Vector2 _pos;
        private Color _color;
        private GameObject _tileObject;

        public bool IsHaveValue => _tileObject != null;
        public int Row { get; private set; }
        public int Colm { get; private set; }

        public Tile(int row,int colm,Vector2 pos,Vector2 size,Color color)
        {
            Path = "Solid_white";
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

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture2D,new Vector2(_pos.X,_pos.Y),_color);//plaster!!!
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


