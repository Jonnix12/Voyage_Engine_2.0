using System;
using System.Collections.Generic;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public class GameObject : BaseObject , IInstantiate , IGameObject , IDisposable
    {
        private string _name;
        private Transform _transform;
        private bool _isActive;
        
        private List<IComponent> _components;
        
        public string Name => _name;
        public Transform Transform => _transform;
        public bool IsActive => _isActive;
        
        public GameObject GameObjectConstructor(Transform transform,string name)
        {
            InitializedBaseObject();

            _components = new List<IComponent>();
            
            transform.SetGameObject(this);

            _name = name;

            _transform = transform;

            return this;
        }

        public void AddComponent<TComponent,T1>(T1 parameter1) where TComponent : IComponent
        {
            var parameterTyps = new[] { typeof(T1) };
            var parameters = new object[] { parameter1 };
            
            AddComponent<TComponent>(parameterTyps, parameters);
        }
        
        public void AddComponent<TComponent,T1,T2>(T1 parameter1,T2 parameter2) where TComponent : IComponent
        {
            var parameterTyps = new[] { typeof(T1) ,typeof(T2) };
            var parameters = new object[] { parameter1 , parameter2};
            
            AddComponent<TComponent>(parameterTyps, parameters);
        }
        
        public void AddComponent<TComponent,T1,T2,T3>(T1 parameter1,T2 parameter2,T3 parameter3) where TComponent : IComponent
        {
            var parameterTyps = new[] { typeof(T1) ,typeof(T2),typeof(T3) };
            var parameters = new object[] { parameter1 , parameter2,parameter3};
            
            AddComponent<TComponent>(parameterTyps, parameters);
        }

        private void AddComponent<TComponent>(Type[] parameterTyps, object[] parameters) where TComponent : IComponent
        {
            var type = typeof(TComponent);
            var typeConstructor = type.GetConstructor(parameterTyps);

            if (typeConstructor == null)
                throw new Exception("Cant get the component constructor that match the inserted parameters");

            TComponent component = (TComponent)typeConstructor.Invoke(parameters);

            _components.Add(component);
        }

        public void SetActive(bool isActive)
        {
            //need active logic
            _isActive = isActive;
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }

        public virtual void Start()
        {
            foreach (var component in _components)
                component.InitComponent(this);
        }

        public virtual void Update()
        {
            foreach (var component in _components)
                component.UpdateComponent();
        }

        public virtual void LateUpdate()
        {
            
        }

        public void Dispose()
        {
            foreach (var component in _components)
                component.Dispose();
        }
    }
}