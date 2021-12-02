using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    public float speed;
    private SlimeBoss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime,maxTime);
        boss = animator.GetComponent<SlimeBoss>();
        
        
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(timer <= 0){
           animator.SetTrigger("idle");
       } else{
           timer -= Time.deltaTime;
           boss.Move();
       }
       
       Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed*4);

       if(boss.dead){
           animator.SetTrigger("dead");
       }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
