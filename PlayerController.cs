using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class PlayerController : MonoBehaviour
{
    public List<GameObject> enemies;
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
        GameObject enemy = RaycastEnemy();
        if(enemy != null)
        {
            transform.rotation
                = Quaternion.LookRotation(enemy.transform.position - transform.position, Vector3.up);
        }
        else
        {
            if (JoyStickMove.instance.joyDir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(JoyStickMove.instance.joyDir, Vector3.up);
            }
        }
        rb.velocity = JoyStickMove.instance.joyDir * speed;


        if (JoyStickMove.instance.touchState == TouchState.IDLE)
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

    public GameObject RaycastEnemy()
    {
        RaycastHit hit;
        LayerMask layermask = 1 << LayerMask.NameToLayer("Enemy");

        for(int i =0; i<enemies.Count; i++)
        {
            bool isHit = Physics.Raycast(transform.position, 
                enemies[i].transform.position - transform.position, out hit, 50, layermask);
            if (isHit && hit.transform.tag == "Enemy")
            {
                //print("isHit " + hit.point);
                return enemies[i];
            }
        }
        return null;
    }
    void OnDrawGizmos()
    {
        RaycastHit hit;
        LayerMask layermask = 1 << LayerMask.NameToLayer("Enemy");
        // LayerMask layermask = LayerMask.GetMask("Enemy");
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, 50, layermask);
        if (isHit && hit.transform.tag == "Enemy")
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, transform.forward * 50);
    }

}