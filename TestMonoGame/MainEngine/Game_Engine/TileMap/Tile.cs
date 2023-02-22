using System;
using Microsoft.Xna.Framework;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.TileMap;

public class Tile : Component, IEquatable<Tile>
{
    private SpriteRenderer _spriteRenderer;

    public Tile(int colm, int row)
    {
        Row = row;
        Colm = colm;
    }

    public GameObject TileObject { get; private set; }

    public bool IsHaveValue => TileObject != null;
    public int Row { get; }
    public int Colm { get; }

    public bool Equals(Tile other)
    {
        if (other == null)
            return false;
        return other.Row == Row && other.Colm == Colm;
    }

    public bool TryAssiagGameObject(GameObject gameObject)
    {
        if (TileObject != null) return false;

        TileObject = gameObject;

        TileObject.Transform.Position = Transform.Position;
        TileObject.Transform.Scale = Transform.Scale * 0.75f;

        return true;
    }

    public void SetToSelected()
    {
        _spriteRenderer ??= GameObject.GetComponent<SpriteRenderer>();

        _spriteRenderer.SetColor(Color.Red);
    }

    public void SetToDeSelected()
    {
        _spriteRenderer.ResetColor();
    }

    public GameObject RemoveTileObject()
    {
        if (TileObject != null)
        {
            var cache = TileObject;
            TileObject = null;

            return cache;
        }

        return null;
    }
}