using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 1500;
    public GameObject deathEffect;
    public CrazyBar healthBar;
    public CanvasGroup bossUI;
    enum bossPhaseState {Start, One, Two}
    bossPhaseState bossState; 
    bool isImmune = true;

    void Start() {
        gameObject.SetActive(false);
        bossUI.alpha = 0f;
        healthBar.setMaxPowerBoss(1500);
        currentHealth = maxHealth;
        bossState = bossPhaseState.Start;
    }

    void FixedUpdate() {
        if(bossState == bossPhaseState.Start) {
            healthBar.IncrementBar(10);
        }
        if(healthBar.slider.value == maxHealth) {
            bossState = updateState(bossState);
        }
    }

    public void startFight() {
        bossUI.alpha = 1f;
    }

    bossPhaseState updateState(bossPhaseState state) {
        if(currentHealth == maxHealth) {
            state = bossPhaseState.One;
            isImmune = false;
        } 
        if(currentHealth == maxHealth/3) {
            state = bossPhaseState.Two;
            isImmune = false;
        }
        return state;
    }

    public void TakeDamage(int damage) {
        if(!isImmune) { 
            currentHealth -= damage;
            healthBar.SetValue(currentHealth);
            if (currentHealth <= 0 ) {
                Die();
            }
        }

    }
    void Die() {
        bossUI.alpha = 0f;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Loader.Load(Loader.Scene.GameWon);
    }

    private int getNumberOfEnemies() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;        
    }
}
