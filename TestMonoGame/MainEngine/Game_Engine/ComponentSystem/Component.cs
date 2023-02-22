using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.ComponentSystem;

public class Component : BaseObject, IComponent
{
    public Transform Transform { get; private set; }

    public GameObject GameObject { get; private set; }

    public virtual void Dispose()
    {
        GameObject.RemoveComponent(this);
        GameObject = null;
        Transform = null;
    }

    public void InitComponent(GameObject gameObject)
    {
        InitializedBaseObject();

        GameObject = gameObject;
        Transform = gameObject.Transform;
    }

    public virtual void UpdateComponent()
    {
    }
}