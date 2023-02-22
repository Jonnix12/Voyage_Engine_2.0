using System;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.ComponentSystem;

public interface IComponent : IDisposable
{
    void InitComponent(GameObject gameObject);
    void UpdateComponent();
}