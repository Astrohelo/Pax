using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBehavior : StateMachineBehaviour
{
    
    private SlimeBoss script;
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script = animator.GetComponent<SlimeBoss>();
       script.rb.gravityScale = 3;

      

       
         animator.SetTrigger("idle");
       


    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script.rb.gravityScale = 3;
    }
}
