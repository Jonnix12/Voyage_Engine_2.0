using System.Collections.Generic;
using Voage_Engine.Assets.Scripts.Player;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

public class TurnManager
{
    private List<Turn> _turns;
    private  Player _currentPlayer;

    public  Player CurrentPlayer => _currentPlayer;

    public TurnManager(int numberOfTurn)
    {
        _turns = new List<Turn>(numberOfTurn);

        for (int i = 0; i < numberOfTurn; i++)
        {
            _turns[i] = new Turn();
        }
    }
}