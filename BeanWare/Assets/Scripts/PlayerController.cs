using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Text comboText;
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
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
        incrementFailedOrder();
    }

    public void playerTakeDamage(int dmg)
    {
        playerHealth -= dmg;
        playerHealthBar.DecrementBar(dmg);
        // check lose condition
        if (playerHealth == 0)
        {
            // LOSE DA GAME
        }
    }

    public void enemyTakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        enemyHealthBar.DecrementBar(dmg);
        // check win condition
        if (enemyHealth == 0)
        {
            // WIN DA GAME - PROGRESS TO NEXT DAY
        }
    }

    public void incrementCombo()
    {
        ComboCounter++;
        comboText.text = ComboCounter + "x";
    }

    public void resetCombo()
    {
        ComboCounter = 0;
        comboText.text = ComboCounter + "x";
    }
}
