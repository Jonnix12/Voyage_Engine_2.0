﻿using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.TileMap;

namespace Voage_Engine.Assets.Scripts.Player;

public class PlayerSelect : Component
{
    private Tile _selectedTile;

    public Tile SelectedTile => _selectedTile;

    public bool IsTileSelected => _selectedTile != null;
    
    public void SelectTile(Tile tile)
    {
        tile.SetToSelected();
        _selectedTile = tile;
    }

    public Tile ReleaseTile()
    {
        var cache = _selectedTile;
        _selectedTile = null;
        cache.SetToDeSelected();
        return cache;
    }
}