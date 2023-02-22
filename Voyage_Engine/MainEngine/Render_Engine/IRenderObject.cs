using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Voyage_Engine.Rendere_Engine;

public interface IRenderObject : IComparable
{
    public int Layer { get; protected set; }
    void LoadContent(ContentManager contentManager);
    void Render(SpriteBatch spriteBatch);
}