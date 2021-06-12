using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerHealth = 3;
    public int enemyHealth = 8;
    public int ComboCounter = 0;
    public int failedOrders = 0;
    public int successfulOrders = 0;

    // Update is called once per frame
    void Update()
    {

    }

    void successfulOrder()
    {
        // when the order is completely without fault
        enemyTakeDamage(1);
        incrementCombo();
    }

    void failedOrder()
    {
        // when the order is failed
        playerTakeDamage(1);
        resetCombo();
    }

    void playerTakeDamage(int dmg)
    {
        playerHealth -= dmg;
        // check lose condition
        if (playerHealth == 0)
        {
            // LOSE DA GAME
        }
    }

    void enemyTakeDamage(int dmg)
    {
        enemyHealth -= dmg;
        // check win condition
        if (enemyHealth == 0)
        {
            // WIN DA GAME - PROGRESS TO NEXT DAY
        }
    }

    void incrementCombo()
    {
        ComboCounter++;
    }

    void resetCombo()
    {
        ComboCounter = 0;
    }
}
