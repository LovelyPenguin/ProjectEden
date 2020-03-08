using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("isPhase2") == false)
        {
            animator.SetFloat("Phase_Bullet_Speed", animator.GetFloat("Phase1_Bullet_Speed"));
            animator.SetFloat("Bullet_Shoot_Interval", animator.GetFloat("Phase1_Shoot_Interval"));
        }
        else if (animator.GetBool("isPhase2") == true)
        {
            animator.SetFloat("Phase_Bullet_Speed", animator.GetFloat("Phase2_Bullet_Speed"));
            animator.SetFloat("Bullet_Shoot_Interval", animator.GetFloat("Phase2_Shoot_Interval"));
        }
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
