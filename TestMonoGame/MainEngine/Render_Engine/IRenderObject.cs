using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Voyage_Engine.Rendere_Engine;

public interface IRenderObject
{
    void LoadContent(ContentManager contentManager);
    void Render(SpriteBatch spriteBatch);
}