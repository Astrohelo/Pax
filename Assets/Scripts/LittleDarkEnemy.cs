using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDarkEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float LeftEnd;
    [SerializeField] private float RightEnd;
    [SerializeField] private float speed ;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    [SerializeField] private PlayerController player;
    private Rigidbody2D rb;
    private Animator anim;


    public Transform attackPoint;
    public float attackRange = 0.8f;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    
    private  void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("idle",true);
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerDetected()){
            
            if(playerIsInRange()){
                Move();
            }
            else{
                 rb.velocity = new Vector2(0, 0);
                anim.SetBool("idle", false);
                anim.SetBool("attack", true);
                anim.SetBool("running", false);
                Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
                
            }

            if (rb.velocity.x > .1 || rb.velocity.x < -.1)
            {
                anim.SetBool("idle", false);
                anim.SetBool("attack", false);
                anim.SetBool("running", true);
            }

        }
        else{
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("idle", true);
            anim.SetBool("attack", false);
            anim.SetBool("running", false);
        }
       
    }
    private void Move()
    {
        

        if (FacingLeft())
        {
            
                transform.localScale = new Vector3(1, 1);
            
                rb.velocity = new Vector2(speed, 0);
                    
            
        }
        else
        {
           
            transform.localScale = new Vector3(-1, 1);
            
             rb.velocity = new Vector2(-speed, 0);
            
        }
    }
    
    private bool FacingLeft(){
        if(transform.position.x - player.transform.position.x  < 0.1f ){
            return true;
        }
        return false;
    }

    private bool playerDetected(){
        if (player.transform.position.x > LeftEnd && player.transform.position.x < RightEnd && transform.position.y-player.transform.position.y> -2 &&transform.position.y-player.transform.position.y < 2 ){
            return true;
        }
        return false;
    }
    private bool playerIsInRange(){
        if( transform.position.x - player.transform.position.x  > -attackRange && transform.position.x - player.transform.position.x  < attackRange){
            return false;
        }
        return true;
    }

    void OnDrawGizmosSelected(){
        if(attackPoint== null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

