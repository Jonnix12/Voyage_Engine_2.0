using Voyage_Engine.Game_Engine.Engine;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.TransformSystem
{
    public class Transform : Node
    {
        private float _positionX;
        private float _positionY;
        private float _scaleX;
        private float _scaleY;
        
        private GameObject _gameObject;

       
        public Vector2 Position { 
            get
            {
                return new Vector2(_positionX, _positionY);
            } set
            {
                _positionX = value.X;
                _positionY = value.Y;
            }
        }

        public Vector2 Scale
        {
            get
            {
                return new Vector2(_scaleX, _scaleY);
            }
            set
            {
                _scaleX = value.X;
                _scaleY = value.Y;
            }
        }

        public GameObject GameObject => _gameObject;
        
        public bool HaveChildren => Children.Count == 0;

        public Transform()
        {
            _positionX = 0;
            _positionY = 0;
            _scaleX = 0;
            _scaleY = 0;
        }

        public Transform(Transform parent)
        {
            SetParent(parent);
        }

        public Transform(Vector2 position, Vector2 scale)
        {
            _positionX = position.X;
            _positionY = position.Y;
            _scaleX = scale.X;
            _scaleY = scale.Y;
            SetParent(MainGameEngine.RootTransform);
        }
        
        public Transform(Vector2 position, Vector2 scale, Transform parent)
        {
            _positionX = position.X;
            _positionY = position.Y;
            _scaleX = scale.X;
            _scaleY = scale.Y;
            SetParent(parent);
        }

        public void MoveTowards(Vector2 destination,float maxDistanceDelta)
        {
            Position = Vector2.MoveTowards(Position, destination, maxDistanceDelta);
        }

        public void SetGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}