using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int damage = 40;

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);

        switch (collision.collider.tag) {
            case "Player":
                Player player = collision.collider.GetComponent<Player>();
                if (player != null) {
                    player.takeDamage();
               try {
                    FindObjectOfType<AudioManager>().Play("player_damaged"); //sound effect
                    } catch(NullReferenceException) {
                        Debug.LogWarning("Could not find audio");
                    }
                }
                break;
            case "Enemy":
                Enemy enemy = collision.collider.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.TakeDamage(damage);

                    try{
                    FindObjectOfType<AudioManager>().Play("skeleton_purple_damaged"); //sound effect
                    }catch(NullReferenceException) {
                        Debug.LogWarning("Could not find audio");
                    }
                }
                break;
            case "Boss":
                Boss boss = collision.collider.GetComponent<Boss>();
                if(boss != null) {
                    boss.TakeDamage(damage);
                    FindObjectOfType<AudioManager>().Play("boss_damaged");
                }
                break;
             default:
                break;
        }

        Destroy(gameObject);
    }
}
