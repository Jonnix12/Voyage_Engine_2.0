using System.Collections.Generic;
using Voyage_Engine.Game_Engine.FactorySystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class Player
{
    private int _playerID;
    private string _playerName;

    public int PlayerId => _playerID;

    public string PlayerName => _playerName;

    private List<CheckersPoc> _checkersPocs;

    public List<CheckersPoc> CheckersPocs => _checkersPocs;

    public Player(int playerId, string playerName)
    {
        _playerID = playerId;
        _playerName = playerName;

        _checkersPocs = new List<CheckersPoc>(12);

        for (int i = 0; i < _checkersPocs.Count; i++)
        {
            _checkersPocs[i] = (CheckersPoc)Factory.Instantiate<CheckersPoc>();
        }
    }

    public void RemoveCheckersPoc(CheckersPoc checkersPoc)
    {
        if (!_checkersPocs.Contains(checkersPoc))
            return;

        _checkersPocs.Remove(checkersPoc);
    }
}