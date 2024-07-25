using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class PlayerController : MonoBehaviour
{
    
    public static PlayerController instance;
    public List<GameObject> enemies;
    Rigidbody rb;
    public float speed = 5;
    public float attackSpeed = 2;
    public GameObject playerShot;
    public Transform spawnPoint;
    Animator animator;
    public PlayerState playerState = PlayerState.IDLE;
    float recoverTime;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        //print(JoyStickMove.instance.joyDir);
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("AttackSpeed", attackSpeed);
    }

    void BasicMove()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
        if (JoyStickMove.instance.joyDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(JoyStickMove.instance.joyDir, Vector3.up);
            
        }
        rb.velocity = JoyStickMove.instance.joyDir * speed;

    }
    void AttackMove()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", true);
        rb.velocity = Vector3.zero;
    }
    void HitMove()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
    }

    void RunMove()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Attack", false);
        if (JoyStickMove.instance.joyDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(JoyStickMove.instance.joyDir, Vector3.up);
            rb.velocity = JoyStickMove.instance.joyDir * speed;
        }
    }



    void Update()
    {

        if(playerState == PlayerState.IDLE)
        {
            GameObject enemy = RaycastEnemy();
            if (enemy == null)
            {
                BasicMove();
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(
                        enemy.transform.position - transform.position,
                        Vector3.up);
                
                playerState = PlayerState.ATTACK;

            }
        }
        else if(playerState == PlayerState.ATTACK)
        {
            AttackMove();
            playerState = PlayerState.IDLE;
        }
        else if (playerState == PlayerState.RUN)
        {
            RunMove();
        }
        
        if (recoverTime >= 0)
        {
            recoverTime -= Time.deltaTime;
            HitMove();
            rb.velocity = JoyStickMove.instance.joyDir * speed * 0.5f;
            if(recoverTime <= 0)
            {
                playerState = PlayerState.IDLE;
            }
        }else{
            rb.velocity = JoyStickMove.instance.joyDir * speed;
        }
        
       
        if (JoyStickMove.instance.touchState == TouchState.DOWN)
        {
            playerState = PlayerState.IDLE;
        }
        else if (JoyStickMove.instance.touchState == TouchState.DRAG)
        {
            playerState = PlayerState.RUN;
        }
        else if (JoyStickMove.instance.touchState == TouchState.UP)
        {
            JoyStickMove.instance.touchState = TouchState.IDLE;
            playerState = PlayerState.IDLE;
        }
        animator.SetFloat("AttackSpeed", attackSpeed);

    }
    //public void ObjTriggerEnter(Collider other)
    public void ObjTriggerEnter(GameObject other)
    {
        print("ObjTriggerEnter" + other.gameObject.tag);
        if(other.tag == "Enemy"){
            recoverTime = 3;
            animator.SetTrigger("HitTrigger");
        }
        //Destroy(other);
    }
    public void OnAttack()
    {
        //print("OnAttack");
        Instantiate(playerShot, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public GameObject RaycastEnemy()
    {
        if (enemies == null || enemies.Count ==0) { 
            return null; 
        }
        RaycastHit hit;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Enemy");
        float shortestDistance = Mathf.Infinity;
        int shortestIndex = -1;
        for (int i = 0; i < enemies.Count; i++)
        {
            bool isHit = Physics.Raycast(transform.position,
                 enemies[i].transform.position - transform.position,
                 out hit, 50, layerMask);
            if (isHit && hit.transform.tag == "Enemy")
            {
                float distance =
                Vector3.Distance(transform.position, enemies[i].
                                 transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    shortestIndex = i;
                }
            }
        }
        if (shortestIndex == -1)
        {
            return null;
        }
        else
        {
            return enemies[shortestIndex];
        }

        /*
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
        */
    }
    /*
    void OnDrawGizmos()
    {
        RaycastHit hit;
        LayerMask layermask = 1 << LayerMask.NameToLayer("Enemy");
        // LayerMask layermask = LayerMask.GetMask("Enemy");
        //print("transform.positionn " + transform.position);
        //print("enemies[0].transform.position "+ enemies[0].transform.position);
        bool isHit = Physics.Raycast(transform.position, 
            enemies[0].transform.position - transform.position, out hit, 50, layermask);
        if (isHit && hit.transform.tag == "Enemy")
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, enemies[0].transform.position - transform.position );
    }
    */

}