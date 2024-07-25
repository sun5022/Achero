using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCheckScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        GameManager.instance.OnEnemyAppear(other.transform.parent.gameObject);
    }
}
