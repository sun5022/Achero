using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public float attackSpeed = 2;
    public GameObject playerShot;
    public Transform spawnPoint;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //print(JoyStickMove.instance.joyDir);
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("AttackSpeed", attackSpeed);
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

        
        if(JoyStickMove.instance.touchState == TouchState.IDLE)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
        else if (JoyStickMove.instance.touchState == TouchState.DOWN)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
        else if (JoyStickMove.instance.touchState == TouchState.DRAG)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }
        else if (JoyStickMove.instance.touchState == TouchState.UP)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
        }
        
    }
    //public void ObjTriggerEnter(Collider other)
    public void ObjTriggerEnter(GameObject other)
    {
        print("ObjTriggerEnter" + other.gameObject.tag);
        Destroy(other);
    }
    public void OnAttack()
    {
        print("OnAttack");
        Instantiate(playerShot, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
    void OnDrawGizmos()
    {
        RaycastHit hit;
        LayerMask layermask = 1 << LayerMask.NameToLayer("Enemy");
        // LayerMask layermask = LayerMask.GetMask("Enemy");
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, 50, layermask);
        if (isHit && hit.transform.tag == "Enemy")
        {
            print("isHit " + hit.point);
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, transform.forward * 50);
    }

}