using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsLoader : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("StartText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        TextAnimator.flashText(text);

        if (Input.anyKeyDown)
        {
            Loader.Load(Loader.Scene.VersusScreen);
        }
    }
}
