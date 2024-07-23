using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEventScript : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = transform.GetComponentInParent<PlayerController>();
    }
    public void Attack()
    {
        print("Attack");
        playerController.OnAttack();
    }
}
