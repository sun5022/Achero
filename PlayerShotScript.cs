using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotScript : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 10;
    int wallCount = 4;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector3.forward * speed;
        rb.velocity = transform.forward * speed;
        //rb.velocity = JoyStickMove.instance.joyDir * speed;

    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Wall"){
            if(wallCount > 0){
                wallCount--;
                transform.forward = 
                Vector3.Reflect(transform.forward, other.GetContact(0).normal);
            }
            else{
                Destroy(gameObject);
            }
        }

    }
    public void ObjTriggerEnter(GameObject obj)
    {
        print("PlayerShot ObjTriggerEnter" + obj.tag);
        if (obj.tag == "Enemy")
        {
            //Destroy(obj);
            GameManager.instance.
            OnEnemyDisAppear(obj);
        }
    }
}
