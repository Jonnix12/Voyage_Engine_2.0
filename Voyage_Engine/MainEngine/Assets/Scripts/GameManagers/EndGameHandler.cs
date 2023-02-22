using Voage_Engine.Assets.Scripts.Player;

namespace Voyage_Engine.Game_Engine.Objects.Scripts;

public class EndGameHandler
{
    private Player[] _players;
    
    public EndGameHandler(Player[] players)
    {
        _players = players;
    }

    public int CheckWin()
    {
        foreach (var player in _players)
        {
            if (player.CheckersPocs.Count <= 0)
            {
                return player.PlayerId;
            }
        }

        return -1;
    }
}