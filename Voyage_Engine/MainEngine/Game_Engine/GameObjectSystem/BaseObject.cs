using Voyage_Engine.Game_Engine.Engine;

namespace Voyage_Engine.Game_Engine.GameObjectSystem;

public abstract class BaseObject
{
    public int InstanceId { get; private set; } = -1;

    protected void InitializedBaseObject()
    {
        InstanceId = InstanceIDGenerator.GetInstanceID(this);
    }
}