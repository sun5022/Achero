using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        print(JoyStickMove.instance.joyDir);
        
    }

    
    void Update()
    {
        if (JoyStickMove.instance.joyDir != Vector3.zero)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(JoyStickMove.instance.joyDir, Vector3.up);
            rb.velocity = JoyStickMove.instance.joyDir * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        /*
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x, 0, y).normalized * speed;
        */
    }
}