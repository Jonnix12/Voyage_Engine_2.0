using System.Collections.Generic;

namespace Voyage_Engine.Game_Engine.TransformSystem
{
    public class Node
    {
        private Transform _parent;
        private List<Transform> _children;

        public Transform Parent => _parent;

        public List<Transform> Children => _children;

        public Node()
        {
            _children = new List<Transform>();
        }

        public void SetParent(Transform parent)
        {
            _parent = parent;
        }

        public void AddChildren(params Transform[] children)
        {
            foreach (var transform in children)
            {
                _children.Add(transform);
            }
        }

        public void RemoveChildren(params Transform[] children)
        {
            foreach (var transform in children)
            {
                _children.Remove(transform);
            }
        }
    }
}