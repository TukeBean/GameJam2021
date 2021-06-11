using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BouncingMovement : MonoBehaviour {

    public enum Direction {
        up, down
    }

    public Rigidbody2D rb;
    public Vector2 movement;
    public Direction direction = Direction.down;
    public float movespeed = 5f;
    public float distance = 100f;
    public float distanceTraveled = 0f;

    void Start() {
        movement.y = -1f;
        movement.x = 0f;
    }

    // Update is called every .02 seconds
    void FixedUpdate() {
        distanceTraveled++;

        if (distanceTraveled >= distance) {
            distanceTraveled = 0;
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

        setMovement();
    }

    void setMovement() {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);

    }


}
