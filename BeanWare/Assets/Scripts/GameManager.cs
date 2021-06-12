using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public AudioSource musicTrack;
    public bool startPlaying;
    public BeatScoller beatScoller;
    public PlayerController player;
    public static GameManager instance;
    public NoteSpawn noteSpawn;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (!startPlaying) {
            if (Input.anyKeyDown) {
                startPlaying = true;
                beatScoller.hasStarted = true;
                musicTrack.Play();
            }
        }
    }

    public void BeatHit() {
        // this is triggered when the ingredient is successfully hit within bounds
        Debug.Log("Hit on Time");
        player.incrementCombo();
        noteSpawn.hitNote();
    }

    public void BeatMissed() {
        // this is triggered when the ingredient is NOT successfully hit within bounds or missed entirely
        noteSpawn.failedNote();
        Debug.Log("Missed!");
        player.resetCombo();
        player.playerTakeDamage(1);
    }
}
