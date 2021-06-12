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
        TextAnimator.flashText(text);

        if (Input.anyKeyDown)
        {
            Loader.Load(Loader.Scene.InstructionsScreen);
        }
    }

}

