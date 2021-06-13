using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenLoader : MonoBehaviour
{
    private Text text;
    private float timer;

    void Start()
    {
        text = GameObject.Find("StartText").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        flashText(text);

        if (Input.anyKeyDown)
        {
            Loader.Load(Loader.Scene.InstructionsScreen);
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

