using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private BoxCollider2D bx2d;


    // Start is called before the first frame update
    void Start()
    {
        bx2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("spacebar DOWN");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ingredient")
        {
            //check the correct key is being pressed, per ingredient
            try
            {       //check the game object is called Lettuce and checks the input equals Spacebar
                if (collision.gameObject.name == "Lettuce" && Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Lettuce SPACED ON!");
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
