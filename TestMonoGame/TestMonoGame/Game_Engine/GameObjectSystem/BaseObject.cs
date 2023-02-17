
using System;
using Voyage_Engine.Game_Engine.Engine;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public abstract class BaseObject
    {
        private int _instanceID = -1;

        public int InstanceId => _instanceID;

        protected void InitializedBaseObject()
        {
            _instanceID = InstanceIDGenerator.GetInstanceID(this);
        }
    }
}