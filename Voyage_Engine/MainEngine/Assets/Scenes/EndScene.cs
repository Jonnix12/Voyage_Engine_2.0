using System.Threading;
using Voage_Engine.Assets.Scripts.Button;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Assest.Scenes;

public class EndScene : Scene
{
    public override int BuildIndex => 1;
    public override string Name => "End Scene";

    public override void StartScene(CancellationToken cancellationToken)
    {
        var button = Factory.Instantiate<Button>();
        button.Input.Click += ResetGame;
        base.StartScene(cancellationToken);
    }

    private void ResetGame(GameObject gameObject)
    {
        SceneManager.SetSceneByIndex(0);
    }
}