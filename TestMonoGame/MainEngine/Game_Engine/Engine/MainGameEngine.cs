using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;
using Keys = System.Windows.Forms.Keys;

namespace Voyage_Engine.Game_Engine.Engine
{
    public class MainGameEngine
    {
        public event Action OnEndUpdate;

        public static string MainPath => Application.StartupPath;

        private Thread _renderThread;

        private MainRenderEngine _mainRenderEngine;
        
        public static Scene CurrentScene => SceneManager.CurrentScene;

        public static Transform RootTransform => CurrentScene.RootTransform;

        public MainGameEngine()
        {
            SceneManager.OnLoadedNewScne += ResetFrame;
            SceneManager.SetFirstScene();
            
            _renderThread = new Thread(StartRenderEngine)
            {
                Name = "Render thread"
            };
            
            _renderThread.Start();
        }

        private void StartRenderEngine()
        {
            _mainRenderEngine = new MainRenderEngine();

            _mainRenderEngine.OnBeforeFirstFrame += Start;
            _mainRenderEngine.OnBeforeFrame += Update;
            _mainRenderEngine.OnCloseWindow += ExitEngine;
            
            _mainRenderEngine.Run();
        }

        private static void Start(CancellationToken cancellationToken)
        {
            if (SceneManager.CurrentScene.IsLoaded)
                return;
            
            SceneManager.CurrentScene.StartScene(cancellationToken);
        }

        private static void Update(CancellationToken cancellationToken)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown((Microsoft.Xna.Framework.Input.Keys) Keys.F))
            {
                SceneManager.NextScene();
                return;
            }
            
            SceneManager.CurrentScene.UpdateScene(cancellationToken);
        }

        private static void LateUpdate()
        {
            
        }

        private void ResetFrame()
        {
            _mainRenderEngine.RestFrame();
        }

        private void ExitEngine()
        {
            _mainRenderEngine.OnBeforeFirstFrame -= Start;

            _mainRenderEngine.OnBeforeFrame -= Update;
            _mainRenderEngine.OnCloseWindow -= ExitEngine;
            SceneManager.OnLoadedNewScne -= ResetFrame;

            //_input.Dispose();
        }
    }

    interface IInitialized : IDisposable
    {
        void Init();
    }
}