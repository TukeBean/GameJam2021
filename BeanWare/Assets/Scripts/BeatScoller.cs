using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScoller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            /* if (Input.anyKeyDown)
            {
                hasStarted = true;
            } */
        }
        else
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
    }
}
