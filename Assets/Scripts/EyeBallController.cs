using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EyeBallController : Enemy
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private float speed;

    [SerializeField] private Transform eyeballGfx;
    public float nextWaypointDistance = 3f;


    [SerializeField] private Path path;
    int currentWaypoint = 0;
    bool reachEndOfPath = false;

    bool activated = false;

    Seeker seeker;
    Rigidbody2D rb;
    [SerializeField] private Animator anim;


    //ATtack
    public float cooldown = 2f; //seconds
    private float lastAttackedAt = -9999f;
    [SerializeField] private laserController laser;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, targetPlayer.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        //Plays the wake up anim
        if (activated == false && Vector2.Distance(rb.position, targetPlayer.position) < 12)
        {
            anim.SetBool("isDetect", true);
        }

        //Starts to move
        if (activated == false && Vector2.Distance(rb.position, targetPlayer.position) < 5)
        {
            anim.SetBool("isMove", true);
            anim.SetBool("isDetect", false);
            anim.SetBool("isIdle", false);

            activated = true;
            InvokeRepeating("UpdatePath", 0f, 0.5f);
        }
        if (activated == true && Vector2.Distance(rb.position, targetPlayer.position) > 25)
        {
            activated=false;
            anim.SetBool("isMove", false);
            anim.SetBool("isDetect", false);
            anim.SetBool("isIdle", true);
        }

        //Attack
        float playerInAttackRange = Vector2.Distance(rb.position, targetPlayer.position);
        if (playerInAttackRange < 2 && Time.time > lastAttackedAt + cooldown)
        {
            laser.attackAnim();
            lastAttackedAt = Time.time;
        }

        //Pathfinding
        if (activated)
        {
            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachEndOfPath = true;
                return;
            }
            else
            {
                reachEndOfPath = false;
            }

            Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = dir * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            if (force.x > 0.01f)
            {
                eyeballGfx.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (force.x < -0.01f)
            {
                eyeballGfx.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
