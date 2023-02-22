using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Voyage_Engine.Rendere_Engine;

public class MainRenderEngine : Game
{
    private static readonly List<IRenderObject> _renderObjects = new();

    private readonly GraphicsDeviceManager _graphics;

    private bool _isFirstFrame;
    private bool _isContentLoaded;
    
    private SpriteBatch _spriteBatch;

    private CancellationTokenSource _tokenSource;

    public MainRenderEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _isFirstFrame = true;

        _tokenSource = new CancellationTokenSource();
    }

    public event Action<CancellationToken> OnBeforeFirstFrame;
    public event Action<CancellationToken> OnBeforeFrame;
    public event Action OnAfterFrame;
    public event Action OnCloseWindow;

    protected override void Initialize()
    {
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        foreach (var renderObject in _renderObjects)
            renderObject.LoadContent(Content);

        if (_renderObjects.Count > 0)
            _renderObjects.Sort();
        
        _isContentLoaded = true;
    }

    protected override async void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var token = _tokenSource.Token;

        if (_isFirstFrame)
        {
            await Task.Run(() => OnBeforeFirstFrame?.Invoke(token), token);
            if (token.IsCancellationRequested)
                return;

            LoadContent();
            _isFirstFrame = false;
        }

        await Task.Run(() => OnBeforeFrame?.Invoke(token), token);
        if (token.IsCancellationRequested)
            return;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        if (!_isContentLoaded)
            return;

        _spriteBatch.Begin();
        foreach (var renderObject in _renderObjects) renderObject.Render(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);

        OnAfterFrame?.Invoke();
    }

    public static void RegisterObject(IRenderObject renderable)
    {
        if (_renderObjects.Contains(renderable))
            return;

        _renderObjects.Add(renderable);
    }

    public static void UnRegisterObject(IRenderObject renderable)
    {
        _renderObjects.Remove(renderable);
    }

    public void RestFrame()
    {
        UnloadContent();
        _tokenSource.Cancel();
        _renderObjects.Clear();
        _isContentLoaded = false;
        _isFirstFrame = true;
        _tokenSource = new CancellationTokenSource();
    }

    protected override void OnExiting(object sender, EventArgs args)
    {
        OnCloseWindow?.Invoke();
        base.OnExiting(sender, args);
    }
}