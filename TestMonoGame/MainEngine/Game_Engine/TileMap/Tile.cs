using System;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.TileMap;

public class Tile : Component, IEquatable<Tile>
{
    private GameObject _tileObject;

    public GameObject TileObject => _tileObject;

    public bool IsHaveValue => _tileObject != null;
    public int Row { get; private set; }
    public int Colm { get; private set; }

    public Tile(int colm,int row)
    {
        Row = row;
        Colm = colm;
    }

    public bool TryAssiagGameObject(GameObject gameObject)
    {
        if (_tileObject != null)
        {
            return false;
        }

        _tileObject = gameObject;

        _tileObject.Transform.Position = Transform.Position;
        _tileObject.Transform.Scale = Transform.Scale * 0.75f;

        return true;
    }

    public GameObject RemoveTileObject()
    {
        if (_tileObject != null)
        {
            var cache = _tileObject;
            _tileObject = null;

            return cache;
        }

        return null;
    }

    public bool Equals(Tile other)
    {
        if (other == null)
            return false;
        return other.Row == Row && other.Colm == Colm;
    }
}