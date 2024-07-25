using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        print("player OnTriggerEnter");
        if (playerController != null)
        {
            //print("OnTriggerEnter" + other.gameObject.tag);
            playerController.ObjTriggerEnter(other.transform.parent.gameObject);
        }
        
    }
}
