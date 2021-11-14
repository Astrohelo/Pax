using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private Transform targetPlayer;

    [SerializeField] private PlayerController player;
    private bool playerIsInCollider = false;
    private float speedOfRotation = 1000;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attackAnim()
    {
        //Rotate towards player
        Vector3 vectorToTarget = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 180, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedOfRotation);


        anim.SetBool("isAttacking", true);
    }
    void turnOffAttack()
    {
        anim.SetBool("isAttacking", false);
    }
    void hitPlayer()
    {
        if (playerIsInCollider)
        {
            player.decreaseLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInCollider = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInCollider = false;
        }
    }
}
