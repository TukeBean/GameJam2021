using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour {
    public void QuitGame() {
        Debug.Log("End Game");
        Application.Quit();
    }
}

