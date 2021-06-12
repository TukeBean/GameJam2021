using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        TitleScreen,
        SplashScreen,
        LoadingScreen,
        GameScene,
        CreditsScreen,
        VersusScreen,
        InstructionsScreen,
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
