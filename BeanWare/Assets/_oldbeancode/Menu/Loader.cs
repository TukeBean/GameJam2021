using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader { 

    //A List of all current scenes
    public enum Scene {
        MainLevel, MainMenu, SplashScreen, GameOver, GameWon
    }

    //Function to be called in other classes to switch scene
    //Ensures an invalid scene isn't called
    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

}
