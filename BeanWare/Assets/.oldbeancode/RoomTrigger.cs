using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Vector3 camStartPos;
    public Vector3 camEndPos;
    public float orthographicSize;
    float lerpTime = 0.0f;
    bool triggerTransition = false;
    public GameObject[] enemyGO;
    void LateUpdate()
    {
        if(triggerTransition) {
            Camera.main.transform.position = Vector3.Lerp(camStartPos, camEndPos, lerpTime);
            Camera.main.orthographicSize = orthographicSize;
            if(lerpTime >= 1.0f) {
                triggerTransition = false;
            } else {
                lerpTime = lerpTime + Time.deltaTime;
            }
        }    
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && getNumberOfEnemies() < 1) {
            triggerTransition = true;
            camStartPos = Camera.main.transform.position;
            lerpTime = 0.0f;
            foreach (GameObject enemy in enemyGO)
            {
                enemy.SetActive(true);
            }
        }
    }

    private int getNumberOfEnemies() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;        
    }

}
