using System.Threading;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects.Scripts;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Assest.Scenes;

public class EndScene : Scene
{
    public override int BuildIndex => 1;
    public override string Name => "End Scene";

    public override void StartScene(CancellationToken cancellationToken)
    {
        Factory.Instantiate<WhiteCheckersPocGameObject>();
        base.StartScene(cancellationToken);
    }
}