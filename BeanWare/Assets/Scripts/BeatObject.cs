using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatObject : MonoBehaviour
{
    public bool canBePressed = false;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                // this is the state at which we can confirm the button has been pressed in the correct position
                gameObject.SetActive(false);

                GameManager.instance.BeatHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision entered");

        if (other.tag == "Center")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("collision exited");
        if (gameObject.activeSelf && other.tag == "Center") {
            canBePressed = false;
            GameManager.instance.BeatMissed();
            gameObject.SetActive(false);
        }
        


    }

}
