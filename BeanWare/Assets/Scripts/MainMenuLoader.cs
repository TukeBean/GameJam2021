using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            Loader.Load(Loader.Scene.GameScene);
        }
    }
}
