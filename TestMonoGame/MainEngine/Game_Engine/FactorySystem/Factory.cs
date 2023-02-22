using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.Engine;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.FactorySystem
{
    public static class Factory
    {
        private static Transform _rootTransform = MainGameEngine.RootTransform;

        /// <summary>
        /// Create a GameObject at position 0,0 and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static GameObject Instantiate<T>() where T: GameObject, new()
        {
            return Instantiate<T>(_rootTransform.Position, _rootTransform, _rootTransform.Scale);
        }

        /// <summary>
        /// Create a GameObject at the received Vector2 position and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <returns></returns>
        public static GameObject Instantiate<T>(Vector2 position) where T: GameObject, new()
        {
            return Instantiate<T>(position, _rootTransform, _rootTransform.Scale);
        }

        /// <summary>
        /// Create a GameObject under the received parent Transform and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static GameObject Instantiate<T>(Transform parent) where T: GameObject, new()
        {
            return Instantiate<T>(parent.Position, parent, parent.Scale);
        }

        /// <summary>
        /// Create a GameObject at the received Vector2 position, scale it to the Vector2 scale parameter and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static GameObject Instantiate<T>(Vector2 position, Vector2 scale) where T: GameObject, new()
        {
            return Instantiate<T>(position, _rootTransform, scale);
        }

        /// <summary>
        /// Create a GameObject at the received Vector2 position, put it under the received parent Transform and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static GameObject Instantiate<T>(Vector2 position, Transform parent) where T: GameObject, new()
        {
            return Instantiate<T>(position, parent, parent.Scale);
        }

        /// <summary>
        ///  Create a GameObject at the received Vector2 position, put it under the received parent Transform, scale it to the Vector2 scale parameter and return it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <param name="parent"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
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