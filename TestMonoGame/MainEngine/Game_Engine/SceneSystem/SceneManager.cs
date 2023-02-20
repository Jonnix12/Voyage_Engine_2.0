using System;
using System.Collections.Generic;
using Voyage_Engine.Assest.Scenes;

namespace Voyage_Engine.Game_Engine.SceneSystem
{
    public static class SceneManager
    {
        public static event Action OnLoadedNewScne;
        
        private static List<Scene> _scenes = new List<Scene>()
        {
            new MainScene(),
        };

        private static Scene _currentScene;

        private static int _sceneIndex;

        public static Scene CurrentScene => _currentScene;

        static SceneManager()
        {
            _sceneIndex = 0;
        }

        public static void RegisterScene(Scene scene) //add new scene to the list 
        {
            _scenes.Add(scene);
        }

        public static Scene GetSceneByIndex(int buildIndex) // get scene by index
        {
            foreach (var Scene in _scenes)
            {
                if (Scene.BuildIndex == buildIndex)
                {
                    return Scene; 
                }
            }
            Debug.LogError($"scene by index {buildIndex} not found"); //debug log for the voyage engine not C# debug
            return null;
                
        }

         public static Scene GetSceneByName(string sceneName) //get scene by name 
        {
            foreach (var Scene in _scenes)
            {
                if (Scene.Name == sceneName)
                {
                    return Scene;
                }
            }
            Debug.LogError($"scene by Name {sceneName} not found"); //debug log for the voyage engine not C# debug
            return null;
        }

        public static void SetFirstScene() //set from start the first scene
        {
            _currentScene = _scenes[_sceneIndex];
        }

        public static void NextScene() //move to next scene
        {
            if (_currentScene != null)
                    _currentScene.EndScene();
            _sceneIndex++;
            
            if (!ValidateSceneIndex(_sceneIndex))
            {
                Debug.Log("no more scenes in the list");
                return;
            }
            
            _currentScene = _scenes[_sceneIndex];
            //_currentScene.StartScene();
            OnLoadedNewScne?.Invoke();
        }

        public static void SetSceneByIndex(int sceneIndex) //set scene by index 
        {
            if (_currentScene != null)
                  _currentScene.EndScene();
            
            if (!ValidateSceneIndex(sceneIndex))
                return;
            
            _sceneIndex = sceneIndex;
            
            _currentScene = _scenes[_sceneIndex];
           // _currentScene.StartScene();
            OnLoadedNewScne?.Invoke();

            Debug.Log(_currentScene.Name);
        }

        private static bool ValidateSceneIndex(int sceneBuildIndex)
        {
            foreach (var scene in _scenes)
            {
                if(scene.BuildIndex == sceneBuildIndex)
                {
                    return true;
                }
            }
            Debug.LogError("build index has not been found");
            return false;
        }
    }
}