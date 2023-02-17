using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Voyage_Engine.Rendere_Engine;

public class MainRenderEngine : Game
{
    public event Action OnBeforeFirstFrame;
    public event Action OnBeforeFrame;
    public event Action OnAfterFrame;
    public event Action OnCloseWindow;
    
    private static List<IRenderObject> _renderObjects;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    public MainRenderEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _renderObjects = new List<IRenderObject>();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        foreach (var renderObject in _renderObjects)
            renderObject.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        OnBeforeFrame?.Invoke();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        foreach (var renderObject in _renderObjects)
        {
            renderObject.Render(_spriteBatch);
        }
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

    protected override void OnExiting(object sender, EventArgs args)
    {
        OnCloseWindow?.Invoke();
        base.OnExiting(sender, args);
    }
}