using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;
using Voyage_Engine.Game_Engine.Objects.Scripts.Players;
using Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;
using Voyage_Engine.Game_Engine.TileMap;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class GameDataHandler : GameObject
{
    private TurnManager _turnManager;
    private PlayersHandler _playersHandler;
    private BoardHandler _boardHandler;

    private PlayerSelect _playerSelect;

    private Tile SelectedTile => _playerSelect.SelectedTile;
    
    public GameDataHandler()
    {
        _boardHandler = new BoardHandler();

        _boardHandler.OnPocEatnd += PocEatend;
        
        _playersHandler = new PlayersHandler();

        _playerSelect = new PlayerSelect();

        Player[] players = new[] {_playersHandler.WhitePlayer, _playersHandler.BlackPlayer};

        _turnManager = new TurnManager(players);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _boardHandler.TileMap[i, j].GetComponent<Button>().Click += BoardClick;
            }
        }
        
    }

    public override void Start()
    {
        _boardHandler.AddBlackPlayerPoc(_playersHandler.BlackPlayer.CheckersPocs.ToArray());
        _boardHandler.AddWhitePlayerPoc(_playersHandler.WhitePlayer.CheckersPocs.ToArray());

        base.Start();
    }

    private void PocEatend(Tile tile)
    {
        Debug.Log($"eAT!!! {tile.Colm} {tile.Row}");

        var poc = tile.TileObject.GetComponent<CheckersPoc>();

        switch (poc.Id)
        {
            case 1:
                tile.RemoveTileObject();
                _playersHandler.WhitePlayer.RemovePoc(poc);
                break;
            case 2:
                tile.RemoveTileObject();
                _playersHandler.WhitePlayer.RemovePoc(poc);
                break;
        }

    }

    private void BoardClick(GameObject gameObject)
    {
        var tile = gameObject.GetComponent<Tile>();
        
        if (_playerSelect.IsTileSelected)
        {
            if (tile.Equals(SelectedTile))
            {
                _playerSelect.ReleaseTile();
            }
            else
            {
                if (tile.IsHaveValue)
                    return;

                if (_boardHandler.MovePoc(SelectedTile.Colm, SelectedTile.Row, tile.Colm, tile.Row,
                        SelectedTile.TileObject.GetComponent<CheckersPoc>().Id))
                {
                    _turnManager.MoveToNextTurn();
                }
                
                _playerSelect.ReleaseTile();
            }
        }
        else
        {
            if (!tile.IsHaveValue)
                return;
            
            if (_turnManager.CurrentPlayer.PlayerId != tile.TileObject.GetComponent<CheckersPoc>().Id)
                return;
            
            _playerSelect.SelectTile(tile);
        }
    }

    ~GameDataHandler()
    {
        _boardHandler.OnPocEatnd -= PocEatend;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _boardHandler.TileMap[i, j].GetComponent<Button>().Click -= BoardClick;
            }
        }
    }
}