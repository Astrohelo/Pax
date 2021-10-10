using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    [SerializeField] private float LeftEnd;
    [SerializeField] private float RightEnd;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private bool FacingLeft()
    {
        if (transform.position.x< 0.1f)
        {
            return true;
        }
        return false;
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
}


