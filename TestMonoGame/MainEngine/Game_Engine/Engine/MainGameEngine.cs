using System;
using System.Threading;
using System.Windows.Forms;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.Engine;

public class MainGameEngine
{
    private MainRenderEngine _mainRenderEngine;

    private readonly Thread _renderThread;

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

    public static string MainPath => Application.StartupPath;

    public static Scene CurrentScene => SceneManager.CurrentScene;

    public static Transform RootTransform => CurrentScene.RootTransform;
    public event Action OnEndUpdate;

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
    }
}