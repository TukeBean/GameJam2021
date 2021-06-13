using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TextAnimator
{

    private static float timer;

    public static void flashText(Text text)
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

    public static void flashTextRed(Text text)
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.5)
        {
            text.color = Color.red;
        }
        if (timer >= 1)
        {
            text.color = Color.white;
            timer = 0;

        }
    }

}
