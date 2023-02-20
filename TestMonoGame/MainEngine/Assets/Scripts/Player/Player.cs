using System.Collections.Generic;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class Player : GameObject , ITurnActor
{
    private int _playerID;
    private string _playerName;

    public bool IsCurrentTurn { get; set; }
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

    public override void Update()
    {
        if (IsCurrentTurn)
        {
            //doStuff
        }
        
        base.Update();
    }

    public void RemoveCheckersPoc(CheckersPoc checkersPoc)
    {
        if (!_checkersPocs.Contains(checkersPoc))
            return;

        _checkersPocs.Remove(checkersPoc);
    }

}