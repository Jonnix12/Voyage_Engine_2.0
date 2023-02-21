using System.Collections.Generic;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects.Scripts;

namespace Voage_Engine.Assets.Scripts.Player;

public class Player : Component
{
    private int _playerID;
    private string _playerName;

   
    public int PlayerId => _playerID;

    public string PlayerName => _playerName;

    private List<CheckersPocGameObject> _checkersPocs;

    public List<CheckersPocGameObject> CheckersPocs => _checkersPocs;

    public Player(string playerName,int playerId)
    {
        _playerName = playerName;
        _playerID = playerId;
        
        _checkersPocs = new List<CheckersPocGameObject>(12);

        for (int i = 0; i < _checkersPocs.Count; i++)
        {
            _checkersPocs[i] = (CheckersPocGameObject)Factory.Instantiate<CheckersPocGameObject>();
        }
    }

    public override void UpdateComponent()
    {
      
        base.UpdateComponent();
    }
    
    public void RemoveCheckersPoc(CheckersPocGameObject checkersPocGameObject)
    {
        if (!_checkersPocs.Contains(checkersPocGameObject))
            return;

        _checkersPocs.Remove(checkersPocGameObject);
    }
}