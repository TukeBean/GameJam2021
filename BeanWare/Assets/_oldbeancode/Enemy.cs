using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    void Start() {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0 ) {
            Die();
        }

    }
    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("skeleton_red_groan"); //sound effect
        Destroy(gameObject);
    }
}
