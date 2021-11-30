using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Behavior : StateMachineBehaviour
{

    public GameObject myPrefab;
    private int slime_int = 3;
    private GameObject boss;
    private SlimeBoss script;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script = animator.GetComponent<SlimeBoss>();
       script.hp -=30;
       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(slime_int==3){
            Instantiate(myPrefab, new Vector3(9.92f, 6.92f, 0),Quaternion.identity);
            slime_int--;
        } else if(slime_int==2){
            Instantiate(myPrefab, new Vector3(7.37f, 6.88f, 0),Quaternion.identity);
            slime_int--;
        } else if(slime_int==1){
            Instantiate(myPrefab, new Vector3(13.28f, 6.64f, 0),Quaternion.identity);
            slime_int--;
        }


        animator.SetInteger("hp",60);
        animator.SetBool("stage1", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       slime_int = 3;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
