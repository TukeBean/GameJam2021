using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    public Transform firePoint;
    public Transform target;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float timer = 60;


    void FixedUpdate() {
        timer--;
        if (timer <= 0f) {
            ShootTarget();
            timer = 100f;
        }
    }

    void ShootTarget() {
        Vector3 fireDirection = (target.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + fireDirection*4, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireDirection * bulletForce, ForceMode2D.Impulse);
    }
}
