using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.TileMap;

namespace Voage_Engine.Assets.Scripts.Player;

public class PlayerSelect : Component
{
    public Tile SelectedTile { get; private set; }

    public bool IsTileSelected => SelectedTile != null;

    public void SelectTile(Tile tile)
    {
        tile.SetToSelected();
        SelectedTile = tile;
    }

    public Tile ReleaseTile()
    {
        var cache = SelectedTile;
        SelectedTile = null;
        cache.SetToDeSelected();
        return cache;
    }
}