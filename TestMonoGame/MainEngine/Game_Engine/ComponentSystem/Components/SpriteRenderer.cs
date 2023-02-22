using Microsoft.Xna.Framework;
using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.ComponentSystem.Components;

public class SpriteRenderer : RenderObject
{
    protected override string Path { get; }
    protected override Color Color { get;  set; }

    public SpriteRenderer(string path,int layer = 0)
    {
        Path = path;
        Layer = layer;
        Color = Color.White;
    }
    
    public SpriteRenderer(string path,int layer,Color color)
    {
        Path = path;
        Layer = layer;
        Color = color;
    }

    public void SetColor(Color color)
    {
        Color = color;
    }
}