using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePointOne;
    public Transform firePointTwo;
    public Transform firePointThree;
    public Transform firePointFour;
    public Transform firePointFive;
    public GameObject bulletPrefab;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public float bulletForce;
    public int playerState;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerState = gameObject.GetComponent<Player>().getState();
        //Debug.Log(playerState);

        if(playerState == 1) {
            bulletPrefab = bullet1;
            bulletForce = 15f;

            shootBullet(bulletPrefab, bulletForce, firePointOne);
            try {
            FindObjectOfType<AudioManager>().Play("player_attack");
            }catch(NullReferenceException) {
                Debug.LogWarning("Could not find audio");
            }
        }
        if(playerState == 2) {
            bulletPrefab = bullet2;
            bulletForce = 30f;

            shootBullet(bulletPrefab, bulletForce, firePointOne);
            try{
            FindObjectOfType<AudioManager>().Play("player_attack");
            }catch(NullReferenceException) {
                Debug.LogWarning("Could not find audio");
            }
        }
        if(playerState == 3) {
            bulletPrefab = bullet3;
            bulletForce = 50f;

            shootBullet(bulletPrefab, bulletForce, firePointOne);
            shootBullet(bulletPrefab, bulletForce, firePointTwo);
            shootBullet(bulletPrefab, bulletForce, firePointThree);
            try {
            FindObjectOfType<AudioManager>().Play("player_attack");
            }catch(NullReferenceException) {
                Debug.LogWarning("Could not find audio");
            }
        }
        if(playerState == 4) {
            bulletPrefab = bullet4;
            bulletForce = 50f;

            //I can't believe I had to spend time doing THIS!!!!!!!!!!
            shootBullet(bulletPrefab, bulletForce, firePointOne);
            shootBullet(bulletPrefab, bulletForce, firePointTwo);
            shootBullet(bulletPrefab, bulletForce, firePointThree);
            shootBullet(bulletPrefab, bulletForce, firePointFour);
            shootBullet(bulletPrefab, bulletForce, firePointFive);
            try {
            FindObjectOfType<AudioManager>().Play("player_attack");
            }catch(NullReferenceException) {
                Debug.LogWarning("Could not find audio");
            }
        }
    }

    void shootBullet(GameObject bulletPrefab, float bulletForce, Transform firePointPos) {
        GameObject bullet = Instantiate(bulletPrefab, firePointPos.position, firePointPos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointPos.up * bulletForce, ForceMode2D.Impulse);
    }
}
