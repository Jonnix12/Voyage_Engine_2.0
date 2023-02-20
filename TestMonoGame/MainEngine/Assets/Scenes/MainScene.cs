using System.Threading;
using Voyage_Engine.Game_Engine.Objects.Scripts;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Assest.Scenes
{
    public class MainScene : Scene
    {
        public override int BuildIndex => 0;
        public override string Name => "MainScene";

        private GameManager _gameManager;

        public override void StartScene(CancellationToken cancellationToken)
        {
            _gameManager = new GameManager();
            base.StartScene(cancellationToken);
        }
    }
}