using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotColliderScript : MonoBehaviour
{
    PlayerShotScript playerShotScript;
    void Start()
    {
        playerShotScript = transform.GetComponentInParent<PlayerShotScript>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (playerShotScript != null)
        {
            print("PlayerShotColliderScript OnTriggerEnter");
            print("transform.parent"+ other);
            
            playerShotScript.ObjTriggerEnter(other.transform.parent.gameObject);
        }
        

    }
}
