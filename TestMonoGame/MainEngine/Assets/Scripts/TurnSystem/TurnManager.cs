using System.Collections.Generic;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

public class TurnManager
{
    private List<Turn> _turns;

    public TurnManager(int numberOfTurn)
    {
        _turns = new List<Turn>(numberOfTurn);

        for (int i = 0; i < numberOfTurn; i++)
        {
            _turns[i] = new Turn();
        }
    }
}