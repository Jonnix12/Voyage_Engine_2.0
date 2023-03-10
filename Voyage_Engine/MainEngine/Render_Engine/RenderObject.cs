using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Voyage_Engine.Game_Engine.ComponentSystem;

namespace Voyage_Engine.Rendere_Engine;

public abstract class RenderObject : Component, IRenderObject
{
    protected Texture2D _texture2D;

    public Texture2D Texture2D => _texture2D;

    protected abstract string Path { get; }
    protected abstract Color Color { get; set; }
    public int Layer { get; set; }
    
    protected RenderObject()
    {
        MainRenderEngine.RegisterObject(this);
    }

    public void LoadContent(ContentManager contentManager)
    {
        _texture2D = contentManager.Load<Texture2D>(Path);
    }

    /// <summary>
    /// Draw the sprite and match it to the GameObject position and scale
    /// </summary>
    /// <param name="spriteBatch"></param>
    public virtual void Render(SpriteBatch spriteBatch)
    {
        var position = new Vector2(Transform.Position.X, Transform.Position.Y);
        spriteBatch.Draw(_texture2D,
            new Rectangle(new Point((int) Transform.Position.X, (int) Transform.Position.Y),
                new Point((int) Transform.Scale.X, (int) Transform.Scale.Y)), Color);
    }

    public override void Dispose()
    {
        MainRenderEngine.UnRegisterObject(this);
        base.Dispose();
    }

    public int CompareTo(object obj)
    {
        var renderObject = (IRenderObject) obj;
        
        if (renderObject.Layer > Layer)
            return -1;
        if (renderObject.Layer < Layer)
            return 1;
        return 0;
    }
}