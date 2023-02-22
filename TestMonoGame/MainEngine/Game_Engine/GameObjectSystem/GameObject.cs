using System;
using System.Collections.Generic;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.GameObjectSystem;

public class GameObject : BaseObject, IInstantiate, IGameObject, IDisposable
{
    private readonly List<IComponent> _components;

    protected GameObject()
    {
        InitializedBaseObject();

        _components = new List<IComponent>();
    }

    public string Name { get; private set; }

    public Transform Transform { get; private set; }

    public bool IsActive { get; private set; }

    public void Dispose()
    {
        for (var i = 0; i < _components.Count; i++)
            _components[i].Dispose();
    }

    public virtual void Start()
    {
    }

    public void Update()
    {
        foreach (var component in _components)
            component.UpdateComponent();
    }

    public void LateUpdate()
    {
        //not Implemented
    }

    /// <summary>
    /// Initialize the GameObject
    /// </summary>
    public GameObject GameObjectConstructor(Transform transform, string name)
    {
        transform.SetGameObject(this);

        Name = name;

        Transform = transform;

        foreach (var component in _components)
            component.InitComponent(this);

        return this;
    }

    /// <summary>
    /// Get a reference to a component of the type T if one is found, otherwise null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetComponent<T>() where T : class, IComponent
    {
        foreach (var component in _components)
            if (component is T foundComponent)
                return foundComponent;

        return null;
    }

    /// <summary>
    /// Adds a component class named className to the game object.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <returns></returns>
    public TComponent AddComponent<TComponent>() where TComponent : IComponent, new()
    {
        var component = new TComponent();

        component.InitComponent(this);
        _components.Add(component);

        return component;
    }

    /// <summary>
    /// Receive a Component and 1 parameter for his constructor. Adds a component class named className to the game object. The parameter have to be in the same order as the component constructor.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <param name="parameter1"></param>
    /// <returns></returns>
    public TComponent AddComponent<TComponent, T1>(T1 parameter1) where TComponent : IComponent
    {
        var parameterTyps = new[] {typeof(T1)};
        var parameters = new object[] {parameter1};

        return AddComponent<TComponent>(parameterTyps, parameters);
    }

    /// <summary>
    /// Receive a Component and 2 parameter for his constructor. Adds a component class named className to the game object. The parameter have to be in the same order as the component constructor.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="parameter1"></param>
    /// <param name="parameter2"></param>
    /// <returns></returns>
    public TComponent AddComponent<TComponent, T1, T2>(T1 parameter1, T2 parameter2) where TComponent : IComponent
    {
        var parameterTyps = new[] {typeof(T1), typeof(T2)};
        var parameters = new object[] {parameter1, parameter2};

        return AddComponent<TComponent>(parameterTyps, parameters);
    }

    /// <summary>
    /// Receive a Component and 3 parameter for his constructor. Adds a component class named className to the game object. The parameter have to be in the same order as the component constructor.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="parameter1"></param>
    /// <param name="parameter2"></param>
    /// <param name="parameter3"></param>
    /// <returns></returns>
    public TComponent AddComponent<TComponent, T1, T2, T3>(T1 parameter1, T2 parameter2, T3 parameter3)
        where TComponent : IComponent
    {
        var parameterTyps = new[] {typeof(T1), typeof(T2), typeof(T3)};
        var parameters = new object[] {parameter1, parameter2, parameter3};

        return AddComponent<TComponent>(parameterTyps, parameters);
    }

    /// <summary>
    /// Receive a Component and 4 parameter for his constructor. Adds a component class named className to the game object. The parameter have to be in the same order as the component constructor.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <param name="parameter1"></param>
    /// <param name="parameter2"></param>
    /// <param name="parameter3"></param>
    /// <param name="parameter4"></param>
    /// <returns></returns>
    public TComponent AddComponent<TComponent, T1, T2, T3, T4>(T1 parameter1, T2 parameter2, T3 parameter3,
        T4 parameter4) where TComponent : IComponent
    {
        var parameterTyps = new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)};
        var parameters = new object[] {parameter1, parameter2, parameter3, parameter4};

        return AddComponent<TComponent>(parameterTyps, parameters);
    }

    /// <summary>
    /// Receive a Component and 5 parameter for his constructor. Adds a component class named className to the game object. The parameter have to be in the same order as the component constructor.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="parameter1"></param>
    /// <param name="parameter2"></param>
    /// <param name="parameter3"></param>
    /// <param name="parameter4"></param>
    /// <param name="parameter5"></param>
    /// <returns></returns>
    public TComponent AddComponent<TComponent, T1, T2, T3, T4, T5>(T1 parameter1, T2 parameter2, T3 parameter3,
        T4 parameter4, T5 parameter5) where TComponent : IComponent
    {
        var parameterTyps = new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)};
        var parameters = new object[] {parameter1, parameter2, parameter3, parameter4, parameter5};

        return AddComponent<TComponent>(parameterTyps, parameters);
    }

    private TComponent AddComponent<TComponent>(Type[] parameterTyps, object[] parameters) where TComponent : IComponent
    {
        var type = typeof(TComponent);
        var typeConstructor = type.GetConstructor(parameterTyps);

        if (typeConstructor == null)
            throw new Exception("Cant get the component constructor that match the inserted parameters");

        var component = (TComponent) typeConstructor.Invoke(parameters);
        component.InitComponent(this);
        _components.Add(component);
        return component;
    }

    public void RemoveComponent(Component component)
    {
        _components.Remove(component);
    }

    public void SetActive(bool isActive)
    {
        //need active logic
        IsActive = isActive;
    }

    public override string ToString()
    {
        return GetType().Name;
    }
}