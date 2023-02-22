using System;
using System.Collections.Generic;
using Voyage_Engine.Assest.Scenes;

namespace Voyage_Engine.Game_Engine.SceneSystem;

public static class SceneManager
{
    private static readonly List<Scene> _scenes = new()
    {
        new MainScene(),
        new EndScene()
    };

    private static int _sceneIndex;

    static SceneManager()
    {
        _sceneIndex = 0;
    }

    public static Scene CurrentScene => _scenes[_sceneIndex];

    public static event Action OnLoadedNewScne;

    public static void RegisterScene(Scene scene) //add new scene to the list 
    {
        _scenes.Add(scene);
    }

    public static Scene GetSceneByIndex(int buildIndex) // get scene by index
    {
        foreach (var Scene in _scenes)
            if (Scene.BuildIndex == buildIndex)
                return Scene;
        Debug.LogError($"scene by index {buildIndex} not found"); //debug log for the voyage engine not C# debug
        return null;
    }

    public static Scene GetSceneByName(string sceneName) //get scene by name 
    {
        foreach (var Scene in _scenes)
            if (Scene.Name == sceneName)
                return Scene;
        Debug.LogError($"scene by Name {sceneName} not found"); //debug log for the voyage engine not C# debug
        return null;
    }

    public static void NextScene() //move to next scene
    {
        if (CurrentScene != null)
            CurrentScene.EndScene();
        _sceneIndex++;

        if (!ValidateSceneIndex(_sceneIndex))
        {
            Debug.Log("no more scenes in the list");
            return;
        }
        
        OnLoadedNewScne?.Invoke();
    }

    public static void SetSceneByIndex(int sceneIndex) //set scene by index 
    {
        if (CurrentScene != null)
            CurrentScene.EndScene();

        if (!ValidateSceneIndex(sceneIndex))
            return;

        _sceneIndex = sceneIndex;

        OnLoadedNewScne?.Invoke();
    }

    private static bool ValidateSceneIndex(int sceneBuildIndex)
    {
        foreach (var scene in _scenes)
            if (scene.BuildIndex == sceneBuildIndex)
                return true;
        Debug.LogError("build index has not been found");
        return false;
    }
}