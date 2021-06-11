using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;

    public Rigidbody2D rb;
    public Camera cam;
    public Transform firepoint;

    Vector2 movementDirection;
    Vector2 mousePosition;
    public Texture2D cursorArrow;
    void Update() {
         //  Process the inputs on a per-frame basis
         ProcessInputs();
    }

    void FixedUpdate() {
         // Move the character on a per-time basis
         Move();
    }

    void ProcessInputs() {
         float moveX = Input.GetAxisRaw("Horizontal");
     try {
        FindObjectOfType<AudioManager>().Play("Walk_Test");
     }catch(NullReferenceException) {
          Debug.LogWarning("Could not find audio");
     }
        float moveY = Input.GetAxisRaw("Vertical");
     try {
        FindObjectOfType<AudioManager>().Play("Walk_Test");
     }catch(NullReferenceException) {
          Debug.LogWarning("Could not find audio");
     }

        movementDirection = new Vector2(moveX,moveY).normalized;

         mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move() {
         // Take our current pos and multiply by movementSpeed
         rb.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
         // get direction of character in relation to mouse pos 
         Vector2 lookDirection = mousePosition - rb.position;
         float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;
         firepoint.eulerAngles = new Vector3(0,0,angle);
         Cursor.SetCursor(cursorArrow,Vector2.zero,CursorMode.ForceSoftware);
    }


}
