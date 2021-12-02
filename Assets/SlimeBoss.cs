using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBoss : Enemy
{
    public int hp;
    private float leftEnd;
    private float rightEnd;
    [SerializeField] private LayerMask ground;

    private Collider2D coll;
    public Rigidbody2D rb;

    [SerializeField] private int maxhp = 9;

    public Slider healthbar;
    private bool facingLeft;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeigth;

    public bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        health = maxhp;
        facingLeft = false;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < health)
        {
            health = hp;
        }
        else if (health < hp)
        {
            hp = health;
        }
        healthbar.value = health;
    }


    public void Move()
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

    public override void Death()
    {

        healthbar.value = 0;
        dead = true;

    }


    public void _Destroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
