using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Engine;

public class InstanceIDGenerator
{
    private static int _instanceIdCount;

    public static int GetInstanceID(BaseObject baseObject)
    {
        if (baseObject.InstanceId != -1)
            return baseObject.InstanceId;

        _instanceIdCount++;

        return _instanceIdCount;
    }
}