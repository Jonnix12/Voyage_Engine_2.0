using System;
using System.Windows.Forms;
using Voyage_Engine.Game_Engine.ResourcesSystem;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Engine
{
    public class MainGameEngine
    {
        public event Action OnEndUpdate;

        public static string MainPath => Application.StartupPath;

        private MainRenderEngine _mainRenderEngine;
        
        public static Scene CurrentScene => SceneManager.CurrentScene;

        public static Transform RootTransform => CurrentScene.RootTransform;

        public MainGameEngine()
        {
            _mainRenderEngine = new MainRenderEngine();

            _mainRenderEngine.OnBeforeFrame += Update;
            _mainRenderEngine.OnCloseWindow += ExitEngine;
            Start();
            _mainRenderEngine.Run();
        }

        private static void Start()
        {
            SceneManager.SetFirstScene();
            
            SceneManager.CurrentScene.StartScene();
        }

        private static void Update()
        {
            SceneManager.CurrentScene.UpdateScene();
        }

        private static void LateUpdate()
        {
            
        }

        private void ExitEngine()
        {
            _mainRenderEngine.OnBeforeFrame -= Update;
            //_input.Dispose();
        }
    }

    interface IInitialized : IDisposable
    {
        void Init();
    }
}