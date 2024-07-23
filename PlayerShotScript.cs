using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void ObjTriggerEnter(GameObject obj)
    {
        print("PlayerShot ObjTriggerEnter" + obj.tag);
        if (obj.tag == "Enemy")
        {
            Destroy(obj);
        }
    }
}
