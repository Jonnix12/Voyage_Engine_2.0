using System.Collections.Generic;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects.Scripts;

namespace Voage_Engine.Assets.Scripts.Player;

public class Player : Component
{
    public Player(string playerName, int playerId)
    {
        PlayerName = playerName;
        PlayerId = playerId;


        CheckersPocs = new List<CheckersPoc>(12);

        for (var i = 0; i < 12; i++)
            switch (playerId)
            {
                case 1:
                    CheckersPocs.Add(Factory.Instantiate<WhiteCheckersPocGameObject>().GetComponent<CheckersPoc>());
                    break;
                case 2:
                    CheckersPocs.Add(Factory.Instantiate<BlackCheckersPocGameObject>().GetComponent<CheckersPoc>());
                    break;
            }
    }


    public int PlayerId { get; }

    public string PlayerName { get; }

    public List<CheckersPoc> CheckersPocs { get; }

    public void RemovePoc(CheckersPoc poc)
    {
        CheckersPocs.Remove(poc);
        poc.GameObject.Dispose();
    }
}