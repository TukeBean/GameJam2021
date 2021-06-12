using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBounce : MonoBehaviour {
    public enum Direction {
        up, down
    }

    public Rigidbody2D rb;
    public Vector2 movement;
    public Direction direction = Direction.down;
    public Boolean accelerating = true;
    public float movespeed = 0.5f;
    public float midpoint = 30f;
    public float distanceTraveled = 0f;

    void Start() {
        movement.y = -1f;
        movement.x = 0f;
    }

    // Update is called every .02 seconds
    void FixedUpdate() {

        if (accelerating) {
            distanceTraveled++;
            if (distanceTraveled >= midpoint) {
                accelerating = false;
            }
        } else {
            distanceTraveled--;
            if (distanceTraveled <= 0) {
                accelerating = true;
                changeDirection();
                randomiseDirection();
            }
        }

        setMovement();
    }

    void setMovement() {
        rb.MovePosition(rb.position + movement * movespeed * distanceTraveled * Time.fixedDeltaTime);
    }

    void changeDirection() {
        switch (direction) {
            case Direction.up:
                direction = Direction.down;
                movement.y = -1f;
                break;
            case Direction.down:
                direction = Direction.up;
                movement.y = 1f;
                break;
        }
    }

    void randomiseDirection() {
        movement.x = UnityEngine.Random.Range(-0.4f, 0.2f);
        midpoint = UnityEngine.Random.Range(30f, 35f);
    }
}
