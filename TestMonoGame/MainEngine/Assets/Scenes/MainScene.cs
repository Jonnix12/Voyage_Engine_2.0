using System.Threading;
using Microsoft.Xna.Framework;
using Voage_Engine.Assets.Scripts.Button;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects.Scripts;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Assest.Scenes;

public class MainScene : Scene
{
    private GameManager _gameManager;
    public override int BuildIndex => 0;
    public override string Name => "MainScene";

    public override void StartScene(CancellationToken cancellationToken)
    {
        var button = (Button)Factory.Instantiate<Button>(new Vector2(1000, 100));
        _gameManager = new GameManager();
        base.StartScene(cancellationToken);
    }
}