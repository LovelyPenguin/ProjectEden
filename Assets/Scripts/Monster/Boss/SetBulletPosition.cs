﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBulletPosition : StateMachineBehaviour
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
        if (animator.GetInteger("PatternKey") == (int)BossStatesPhase1.VL_P1_BatShot1)
        {
            animator.GetComponent<VL_P1_BatShot1>().SetBulletPostion();
        }

        else if (animator.GetInteger("PatternKey") == (int)BossStatesPhase1.VL_P1_BatShot2)
        {
            animator.GetComponent<VL_P1_BatShot2>().SetBulletPostion();
        }

        else if (animator.GetInteger("PatternKey") == (int)BossStatesPhase1.VL_P1_BatShot3)
        {
            for (int i = 0; i < 5; i++)
            {
                animator.GetComponent<VL_P1_BatShot3>().SetBulletPostion();
            }
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("CC");
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
