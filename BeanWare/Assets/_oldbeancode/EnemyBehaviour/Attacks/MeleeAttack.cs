using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public Transform attackPoint;
    public float attackRange = 3f;
    public float timer = 60;

    void FixedUpdate() {
        timer--;
        if (timer <= 0f) {
            timer = 60;
            Collider2D[] hitEntities = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

            foreach (Collider2D entity in hitEntities) {
                if (entity.tag == "Player") {
                    entity.GetComponent<Player>().takeDamage();
                }
            }
        }
    }

    void OnDrawGizmosSelected() {
        if(attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
