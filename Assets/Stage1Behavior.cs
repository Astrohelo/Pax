using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Behavior : StateMachineBehaviour
{

    public GameObject myPre1;
    public GameObject myPre2;
    public GameObject myPre3;
    private GameObject boss;
    private SlimeBoss script;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script = animator.GetComponent<SlimeBoss>();

       Instantiate(myPre1, new Vector3(9.92f, 6.92f, 0),Quaternion.identity);
       Instantiate(myPre2, new Vector3(7.37f, 6.88f, 0),Quaternion.identity);
       Instantiate(myPre3, new Vector3(13.28f, 6.64f, 0),Quaternion.identity);

       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject[] slimes = GameObject.FindGameObjectsWithTag("Slime");  


        script.hp = 9 - (3-slimes.Length);
        Debug.Log(slimes.Length);

        if(slimes.Length==0){
            animator.SetTrigger("falling");
        } 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
