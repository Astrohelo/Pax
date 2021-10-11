using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    [SerializeField] private float leftEnd;
    [SerializeField] private float rightEnd;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeigth = 15f;

    private bool facingLeft = true;

    private Collider2D coll;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
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
                    transform.localScale = new Vector3(1, 1, 1);
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
                    transform.localScale = new Vector3(-1, 1, 1);
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


