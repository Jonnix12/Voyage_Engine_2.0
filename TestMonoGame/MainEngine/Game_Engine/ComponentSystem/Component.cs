using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.ComponentSystem
{
    public class Component : BaseObject , IComponent
    {
        private Transform _transform;
        private GameObject _gameObject;

        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public virtual void Dispose()
        {
        }

        public virtual void InitComponent(GameObject gameObject)
        {
            InitializedBaseObject();
            
            _gameObject = gameObject;
            _transform = gameObject.Transform;
        }

        public virtual void UpdateComponent()
        {
        }
    }
}