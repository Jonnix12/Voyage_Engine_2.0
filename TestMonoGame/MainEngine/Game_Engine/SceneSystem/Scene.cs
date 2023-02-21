using System;
using System.Threading;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.SceneSystem
{
    public abstract class Scene : IDisposable
    {
        private Transform _rootTransform;

        public Transform RootTransform => _rootTransform;

        public abstract int BuildIndex { get; }
        public abstract string Name { get; }

        public  bool  IsLoaded { get; private set; }

        protected Scene()
        {
            _rootTransform = new Transform();
        }
        
        public virtual void StartScene(CancellationToken cancellationToken) //start scene
        {
            StartChildren(RootTransform,cancellationToken);
            IsLoaded = true;
        }

        public virtual void UpdateScene(CancellationToken cancellationToken) //update scene
        {
            UpdateChildren(RootTransform,cancellationToken);
        }

        public virtual void EndScene() //end scene
        {
            Dispose();
            IsLoaded = false;
        }
        
        private void StartChildren(Transform transform,CancellationToken cancellationToken)
        {
            var child = transform.Children;
            
            for (int i = 0; i < child.Count; i++)
            {
                child[i].GameObject.Start();
                
                if (cancellationToken.IsCancellationRequested)
                    return;

                if (child[i].HaveChildren)
                {
                    StartChildren(child[i],cancellationToken);
                }
            }
        }
        
        private  void UpdateChildren(Transform transform,CancellationToken cancellationToken)
        {
            var child = transform.Children;
            
            for (int i = 0; i < child.Count; i++)
            {
                child[i].GameObject.Update();
                
                if (cancellationToken.IsCancellationRequested)
                    return;

                if (child[i].HaveChildren)
                {
                    UpdateChildren(child[i],cancellationToken);
                }
            }
        }
        
        public override int GetHashCode()
        {
            return BuildIndex;
        }

        public void Dispose()
        {
            foreach (var child in _rootTransform.Children)
            {
                if (child.HaveChildren)
                {
                    child.GameObject.Dispose();
                }
            }
        }
    }
}