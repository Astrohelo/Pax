using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    [SerializeField] private float leftEnd;
    [SerializeField] private float rightEnd;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeigth = 15f;


    private bool facingLeft;

    private Collider2D coll;
    private Rigidbody2D rb;
    [SerializeField] private int concreteHealth;

    // Start is called before the first frame update
    void Start()
    {
        facingLeft = Random.Range(0, 2) > 0;
        health=concreteHealth;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }



    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftEnd)
            {
                if (transform.localScale.x != 1)
                {
                    float move = Random.Range(0.94f,1.06f);
                    transform.localScale = new Vector3(move, 1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeigth);
                }

            }
            else
            {

                facingLeft = false;

            }
        }
        else
        {
            if (transform.position.x < rightEnd)
            {
                if (transform.localScale.x != -1)
                {
                    float move = Random.Range(-0.9f,-1.1f);
                    transform.localScale = new Vector3(move, 1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeigth);
                }

            }
            else
            {

                facingLeft = true;

            }
        }
    }

    
}


