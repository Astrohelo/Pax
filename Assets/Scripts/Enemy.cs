using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //protected Animator anim;
    //protected Rigidbody2D rb;
    protected int health;
    public GameObject effect;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }

    public void gotHit()
    {
        health--;
        Instantiate(effect, transform.position, Quaternion.identity);
        if (health == 0)
        {
            Death();
        }
    }
    public virtual void Death()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
