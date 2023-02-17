using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.ComponentSystem.Components;

public class SpriteRenderer : RenderObject
{
    protected override string Path { get; }

    public SpriteRenderer(string path,int layer = 0)
    {
        Path = path;
        Layer = layer;
    }
    
}