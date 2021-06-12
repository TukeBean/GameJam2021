using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SprayAttack : MonoBehaviour {
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

        Vector3 perp = new Vector3(-fireDirection.y, fireDirection.x, 0).normalized;

        Vector3 fireDirection1 = ((target.position - perp*5) - firePoint.position).normalized;
        Vector3 fireDirection2 = ((target.position + perp*5) - firePoint.position).normalized;

        fireBullet(fireDirection);
        fireBullet(fireDirection1);
        fireBullet(fireDirection2);
    }

    void fireBullet(Vector3 direction) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + direction * 2, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
