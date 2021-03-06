using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource musicTrack;
    public bool startPlaying;
    public BeatScoller beatScoller;
    public PlayerController player;
    public static GameManager instance;
    public NoteSpawn noteSpawn;
    public GameObject youWinPrompt;
    public GameObject youLosePrompt;
    public GameObject punchPrompt;
    public bool gameOver = false;
    public int dayCount = 1;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            startPlaying = true;
            musicTrack.Play();
        }

        if (gameOver)
        {
            StartCoroutine(WaitBeforeTransiton());
            
        }
    }

    public void setWinPrompt(bool bl)
    {
        Debug.Log("----------------hello!!!!!!");
         //youWinPrompt.SetActive(bl);
        punchPrompt.SetActive(false);
        Loader.Load(Loader.Scene.WinScreen);
    }
    public void setLosePrompt(bool bl)
    {
        youLosePrompt.SetActive(bl);
        punchPrompt.SetActive(false);
       
    }

    public void setPunchBool(bool bl)
    {
        player.setPunchBool(bl);
        animator.SetBool("punch", bl);
    }

    public void BeatHit()
    {
        // this is triggered when the ingredient is successfully hit within bounds
        Debug.Log("Hit on Time");
        player.incrementCombo();
        noteSpawn.hitNote();
    }

    public void BeatMissed()
    {
        // this is triggered when the ingredient is NOT successfully hit within bounds or missed entirely
        noteSpawn.failedNote();
        Debug.Log("Missed!");
        player.resetCombo();
        player.playerTakeDamage(1);
    }

    public void loseGame()
    {
        // trigger you lose prompt
        setLosePrompt(true);
        // then tranisition to lose screen
        gameOver = true;
        // play kazoo music again

    }

    public void progressToNextDay()
    {
        // trigger you win prompt
        setWinPrompt(true);
        // refill healthbars
        player.setPlayerHealth(3);
        // reset combocounter
       // player.resetCombo();
        // trigger next day's order in NoteSpawn
       // dayCount++;
        // noteSpawn.setDay(dayCount);
    }

    //Waits for 3 seconds then changes the scene
    IEnumerator WaitBeforeTransiton()
    {
        yield return new WaitForSeconds(3);
        Loader.Load(Loader.Scene.CreditsScreen);
    }
}
