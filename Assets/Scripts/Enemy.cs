using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //protected Animator anim;
    //protected Rigidbody2D rb;
    protected int health;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }

    public void gotHit(){
        health--;
        if (health==0){
            Death();
        }
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
