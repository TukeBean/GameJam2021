using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersusScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This method is required to use "WaitForSeconds"
        StartCoroutine(WaitBeforeTransiton());
    }

    //Waits for 3 seconds then changes the scene
    IEnumerator WaitBeforeTransiton()
    {
        yield return new WaitForSeconds(10);
        Loader.Load(Loader.Scene.GameScreen);
    }
}
