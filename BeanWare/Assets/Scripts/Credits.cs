using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{


    private float textSpeed;
    private Text text;


    void Start()
    {
        text = GameObject.Find("CreditsText").GetComponent<Text>();
    }

    void Update()
    {
        if (text.transform.position.y < 1800)
        {
            text.transform.Translate(0, 3, 0);
        }
        else
        {
            Loader.Load(Loader.Scene.TitleScreen);
        }

        

    }


}
