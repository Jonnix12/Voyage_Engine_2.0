using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.Engine;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.FactorySystem
{
    public static class Factory
    {
        private static Transform _rootTransform = MainGameEngine.RootTransform;
        
        public static GameObject Instantiate<T>() where T: GameObject, new()
        {
            return Instantiate<T>(_rootTransform.Scale, _rootTransform, _rootTransform.Scale);
        }

        public static GameObject Instantiate<T>(Vector2 position) where T: GameObject, new()
        {
            return Instantiate<T>(position, _rootTransform, _rootTransform.Scale);
        }

        public static GameObject Instantiate<T>(Transform parent) where T: GameObject, new()
        {
            return Instantiate<T>(parent.Position, parent, parent.Scale);
        }

        public static GameObject Instantiate<T>(Vector2 position, Vector2 scale) where T: GameObject, new()
        {
            return Instantiate<T>(position, _rootTransform, scale);
        }

        public static GameObject Instantiate<T>(Vector2 position, Transform parent) where T: GameObject, new()
        {
            return Instantiate<T>(position, parent, parent.Scale);
        }

        public static GameObject Instantiate<T>(Vector2 position, Transform parent, Vector2 scale) where T: GameObject, new()
        {
            T gameObject = new T();
            
            var transform = new Transform(position,scale,parent);
            
            gameObject.GameObjectConstructor(transform,typeof(T).Name);
            
            _rootTransform.AddChildren(gameObject.Transform);
            
            return gameObject;
        }
    }
    
    public interface IInstantiate
    {
        GameObject GameObjectConstructor(Transform transform,string name);
    }
}