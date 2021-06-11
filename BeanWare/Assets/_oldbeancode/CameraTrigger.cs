using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {
    private string[] cameraNames= {"Main Camera", "Camera1"};
    private Camera oldCam, newCam;
    void Start() {
        for(int cameraCount = 0; cameraCount<cameraNames.Length; cameraCount++) {
            Camera currentCam = GameObject.Find(cameraNames[cameraCount]).GetComponentInChildren<Camera>();
            if(currentCam.enabled) {
                oldCam = currentCam;
                newCam = GameObject.Find(cameraNames[++cameraCount]).GetComponentInChildren<Camera>();
                break;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(oldCam);
        if(other.gameObject.tag == "Player") {
        oldCam.enabled=false;
        newCam.enabled=true;
        
        }
    }
}
