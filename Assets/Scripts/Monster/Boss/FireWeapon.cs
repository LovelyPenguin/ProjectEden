using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        VL_P1_BatShot1(animator);
        VL_P1_BatShot2(animator);
        //VL_P1_BatShot3(animator);

        animator.SetInteger("PreviousPatternKey", 0);
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

    void VL_P1_BatShot1(Animator animator)
    {
        if (animator.GetInteger("PreviousPatternKey") == (int)BossStatesPhase1.VL_P1_BatShot1)
        {
            animator.gameObject.GetComponent<VL_P1_BatShot1>().BulletFire();
            animator.gameObject.GetComponent<VL_P1_BatShot1>().ResetData();
        }
    }

    void VL_P1_BatShot2(Animator animator)
    {
        if (animator.GetInteger("PreviousPatternKey") == (int)BossStatesPhase1.VL_P1_BatShot2)
        {
            animator.gameObject.GetComponent<VL_P1_BatShot2>().BulletFire();
            animator.gameObject.GetComponent<VL_P1_BatShot2>().ResetData();
        }
    }

    void VL_P1_BatShot3(Animator animator)
    {
        if (animator.GetInteger("PreviousPatternKey") == (int)BossStatesPhase1.VL_P1_BatShot3)
        {
            animator.gameObject.GetComponent<VL_P1_BatShot3>().ResetData();
        }
    }
}
