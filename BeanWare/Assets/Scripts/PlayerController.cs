using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text comboText;
    public Text comboTextShadow;
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    public bool punchBool;
    public int playerHealth = 3;
    public int enemyHealth = 8;
    public int ComboCounter = 0;
    public int failedOrders = 0;
    public int successfulOrderCounter = 0;
    public AudioSource punchNoise;
    public AudioSource badNoise;
    private void Start()
    {
        // set the health of the player and enemy at start of scene
        playerHealthBar.setMaxHealth(3);
        enemyHealthBar.setMaxHealthEnemy(8);
        this.punchBool = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (punchBool)
            {
                // PAWNCH
                // GOES
                // HERE
                punchNoise.Play();
                GameManager.instance.setPunchBool(false);
            }
        }
    }

    public bool getPunchBool()
    {
        return this.punchBool;
    }

    public void setPunchBool(bool bl)
    {
        this.punchBool = bl;
    }

    public void setEnemyHealth(int hp)
    {
        enemyHealth = hp;
        enemyHealthBar.setMaxHealthEnemy(hp);
    }

    public void setPlayerHealth(int hp)
    {
        playerHealth = hp;
        playerHealthBar.setMaxHealth(hp);
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public int getEnemyHealth()
    {
        return enemyHealth;
    }

    public void successfulOrder()
    {
        // when the order is completely without fault
        enemyTakeDamage(1);
        incrementCombo();
        incrementSuccessfulOrder();
    }

    public void incrementSuccessfulOrder()
    {
        successfulOrderCounter++;
    }

    public void incrementFailedOrder()
    {
        failedOrders++;
    }

    public void failedOrder()
    {
        // when the order is failed
        playerTakeDamage(1);
        incrementFailedOrder();
    }

    public void playerTakeDamage(int dmg)
    {
        playerHealth -= dmg;
        playerHealthBar.DecrementBar(dmg);
        badNoise.Play();
        // check lose condition
        if (playerHealth == 0)
        {
            // LOSE DA GAME
            GameManager.instance.loseGame();
        }
    }

    public void enemyTakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        enemyHealthBar.DecrementBar(dmg);
        // check win condition
        if (enemyHealth < 1)
        {
            // WIN DA GAME - PROGRESS TO NEXT DAY
            GameManager.instance.progressToNextDay();
        }
    }

    public void incrementCombo()
    {
        ComboCounter++;
        comboText.text = ComboCounter + "x";
        comboTextShadow.text = ComboCounter + "x";
    }

    public void resetCombo()
    {
        ComboCounter = 0;
        comboText.text = ComboCounter + "x";
        comboTextShadow.text = ComboCounter + "x";
    }
}
