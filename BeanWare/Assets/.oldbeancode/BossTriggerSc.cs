using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerSc : MonoBehaviour
{
    public GameObject bossGO;
    Boss bossObj;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            bossGO.SetActive(true);
            Boss bossObj = bossGO.GetComponent<Boss>();
            bossObj.startFight();
        }
    }
}
