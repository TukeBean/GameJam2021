using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    // this is the HARD cap of the bar's power limit - we maybe need to scale this higher to allow for more FUN!
    public int maxPower = 100;
    //This is how much the bar increases when the player is hit
    public int damage = 5;
    // The current power of the bar - which changes the slider scale
    public int currentPower;
    // the reference to the CrazyBar!
    public CrazyBar crazyBar;
    // the reference to our Facecam
    public Facecam facecam;
    // the various player states
    enum playerState {One, Two, Three, Four}
    // the actual player state
    playerState playState;
    public Sprite playerSpriteTest;
    public Sprite playerSpriteTest2; 
    public Sprite playerSpriteTest3; 
    public Sprite playerSpriteTest4;  
    

    // Start is called before the first frame update
    void Start() {
        currentPower = 0;
        crazyBar.SetValue(0);
        playState = playerState.One;        
    }

    // Update is called once per frame
    void Update()
    {
        playState = updateState(playState);
        changeState(playState);
        updateSprite(playState);
        
    }

    // FixedUpdate is called on fixed time interval
    void FixedUpdate() {
        IncrementPower(1);
    }
    
    void updateSprite(playerState state) {
        if(state == playerState.One) {
            this.GetComponent<SpriteRenderer>().sprite = playerSpriteTest;
        }
        if(state == playerState.Two) {
            this.GetComponent<SpriteRenderer>().sprite = playerSpriteTest2;
        }
        if(state == playerState.Three) {
            this.GetComponent<SpriteRenderer>().sprite = playerSpriteTest3;
        }
        if(state == playerState.Four) {
            this.GetComponent<SpriteRenderer>().sprite = playerSpriteTest4;
        }
    }

    // Increase bar by fixed amount
    void IncrementPower(int power) {
        if(currentPower != maxPower)
            currentPower += power;
            crazyBar.IncrementBar(power);
    }

    // decrease bar by fixed amount
    void DecrementPower(int power) {
        // this is kind of broken currently 
        // due to the space-bar removal of power
        // but it is out of spec so not an issue
        currentPower -= power;
        crazyBar.DecrementBar(power);
    }

    // return the player power
    public int getPower() {
        return currentPower;
    }

    public int getState() {
    int state = 0;
        if(playState == playerState.One)
            state = 1;
        if(playState == playerState.Two)
            state = 2;
        if(playState == playerState.Three)
            state = 3;
        if(playState == playerState.Four)
            state = 4;        
    return state;
    }

    // change the player facecam based on the state
    void changeState (playerState state) {
        if(state == playerState.One)
            //set facecam to normal
            facecam.UpdateFacecam(1);
        if(state == playerState.Two)
            facecam.UpdateFacecam(2);
        if(state == playerState.Three)
            facecam.UpdateFacecam(3);
        if(state == playerState.Four)
            facecam.UpdateFacecam(4);
    }

    // update the player state based on power value
    playerState updateState(playerState state) {
        if (currentPower >= maxPower) {
            state = playerState.Four;
        } else if(currentPower >= maxPower / 2) {
            state = playerState.Three;
        } else if(currentPower >= maxPower / 3) {
            state = playerState.Two;
        } else if(currentPower >= maxPower / 4) {
            state = playerState.One;
        }  
    return state;
    }

    // return the player power
    public void takeDamage() {
        IncrementPower(damage);

        if(currentPower >= (maxPower + 1000)) {
            Die();
        }
    }

    

    public void Die() {
        Loader.Load(Loader.Scene.GameOver);
    }
}
