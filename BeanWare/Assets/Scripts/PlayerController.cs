using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerHealth = 3;
    public int enemyHealth = 8;
    public int ComboCounter = 0;
    public int failedOrders = 0;
    public int successfulOrderCounter = 0;

    // Update is called once per frame
    void Update()
    {

    }

    public void setEnemyHealth(int hp)
    {
        enemyHealth = hp;
    }

    public void setPlayerHealth(int hp)
    {
        playerHealth = hp;
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
        resetCombo();
    }

    public void playerTakeDamage(int dmg)
    {
        playerHealth -= dmg;
        // check lose condition
        if (playerHealth == 0)
        {
            // LOSE DA GAME
        }
    }

    public void enemyTakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        // check win condition
        if (enemyHealth == 0)
        {
            // WIN DA GAME - PROGRESS TO NEXT DAY
        }
    }

    public void incrementCombo()
    {
        ComboCounter++;
    }

    public void resetCombo()
    {
        ComboCounter = 0;
    }
}
