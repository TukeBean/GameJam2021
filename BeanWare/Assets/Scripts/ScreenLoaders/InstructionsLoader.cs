using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsLoader : MonoBehaviour
{
    private Text text;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("StartText").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flashText(text);

        if (Input.anyKeyDown)
        {
            Loader.Load(Loader.Scene.VersusScreen);
        }
    }

    void flashText(Text text)
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.5)
        {
            text.enabled = true;
        }
        if (timer >= 1)
        {
            text.enabled = false;
            timer = 0;
        }
    }
}
