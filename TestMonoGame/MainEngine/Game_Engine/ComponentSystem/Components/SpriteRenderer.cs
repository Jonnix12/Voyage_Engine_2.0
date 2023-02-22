using Microsoft.Xna.Framework;
using Voyage_Engine.Rendere_Engine;

namespace Voyage_Engine.Game_Engine.ComponentSystem.Components;

public class SpriteRenderer : RenderObject
{
    private readonly Color _defaltColor;

    public SpriteRenderer(string path, int layer = 0)
    {
        Path = path;
        Layer = layer;
        Color = Color.White;
        _defaltColor = Color.White;
    }

    public SpriteRenderer(string path, int layer, Color color)
    {
        Path = path;
        Layer = layer;
        Color = color;
        _defaltColor = color;
    }

    protected override string Path { get; }
    protected sealed override Color Color { get; set; }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void ResetColor()
    {
        Color = _defaltColor;
    }
}