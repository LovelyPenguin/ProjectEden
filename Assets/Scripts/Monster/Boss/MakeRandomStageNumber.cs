using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRandomStageNumber : StateMachineBehaviour
{
    public int range;
    public float timer = 1.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("Debug_Mode"))
        {
            timer = 1.5f;
            int number = Random.Range(1, range + 1);
            Debug.Log(number);
            animator.SetInteger("PatternKey", number);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("Debug_Mode"))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                int number = Random.Range(1, range + 1);
                Debug.Log(number);
                animator.SetInteger("PatternKey", number);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
