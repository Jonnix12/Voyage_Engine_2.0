using System.Collections.Generic;

namespace Voyage_Engine.Game_Engine.TransformSystem;

public class Node
{
    public Node()
    {
        Children = new List<Transform>();
    }

    public Transform Parent { get; private set; }

    public List<Transform> Children { get; }

    public void SetParent(Transform parent)
    {
        Parent = parent;
    }

    public void AddChildren(params Transform[] children)
    {
        foreach (var transform in children) Children.Add(transform);
    }

    public void RemoveChildren(params Transform[] children)
    {
        foreach (var transform in children) Children.Remove(transform);
    }
}