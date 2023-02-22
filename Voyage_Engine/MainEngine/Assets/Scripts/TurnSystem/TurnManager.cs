using System.Collections.Generic;
using Voage_Engine.Assets.Scripts.Player;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.TurnSystem;

public class TurnManager
{
    private Turn _currentTurn;

    private int _currentTurnIndex;
    private readonly List<Turn> _turns;

    public TurnManager(Player[] players)
    {
        _currentTurnIndex = 0;

        _turns = new List<Turn>(players.Length);

        for (var i = 0; i < players.Length; i++) _turns.Add(new Turn(players[i]));

        SetTurn(_currentTurnIndex);
    }

    public Player CurrentPlayer => _currentTurn.Player;

    private void SetTurn(int turnIndex)
    {
        _currentTurn = _turns[turnIndex];
    }

    public void MoveToNextTurn()
    {
        _currentTurnIndex++;

        if (_currentTurnIndex >= _turns.Count)
            _currentTurnIndex = 0;

        _currentTurn = _turns[_currentTurnIndex];
    }
}