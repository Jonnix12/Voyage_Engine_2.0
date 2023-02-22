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

    private List<CheckersPoc> _checkersPocs;

    public List<CheckersPoc> CheckersPocs => _checkersPocs;

    public Player(string playerName,int playerId)
    {
        _playerName = playerName;
        _playerID = playerId;
        
        
        _checkersPocs = new List<CheckersPoc>(12);

        for (int i = 0; i < 12; i++)
        {
            switch (playerId)
            {
                case 1:
                    _checkersPocs.Add(Factory.Instantiate<WhiteCheckersPocGameObject>().GetComponent<CheckersPoc>());
                    break;
                case 2:
                    _checkersPocs.Add(Factory.Instantiate<BlackCheckersPocGameObject>().GetComponent<CheckersPoc>());
                    break;
            }
        }
    }

    public void RemovePoc(CheckersPoc poc)
    {
        _checkersPocs.Remove(poc);
        poc.GameObject.Dispose();
    }
    
}