using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    
    //Function for play button to change to game screen
    public void PlayGame() {
        Loader.Load(Loader.Scene.MainLevel);
    }

    //Function for quit button to close game
    //If testing in unity game wont quit but you can see the log message
    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

