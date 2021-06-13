using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //This method is required to use "WaitForSeconds"
        StartCoroutine(WaitBeforeTransiton());
    }

    private void FixedUpdate()
    {
        spriteRenderer.size += new Vector2(0.025f, 0.02f);
    }

    //Waits for 3 seconds then changes the scene
    IEnumerator WaitBeforeTransiton()
    {
        yield return new WaitForSeconds(10);
        Loader.Load(Loader.Scene.TitleScreen);
    }
}
