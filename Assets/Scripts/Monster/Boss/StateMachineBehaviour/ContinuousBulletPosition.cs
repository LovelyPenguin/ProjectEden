using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBulletPosition : StateMachineBehaviour
{
    private bool isPlantBomb = false;
    public bool isStartLeft = false;
    [SerializeField]
    private float xpos = 0;
    //[SerializeField]
    //private float ypos = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("PatternKey") == (int)BossStatesPhase1.VL_P1_BatShot1 && isPlantBomb == false)
        {
            if (animator.transform.position.x >= xpos && isStartLeft)
            {
                animator.GetComponent<VL_P1_BatShot1>().SetBulletPostion(xpos, animator.transform.position.y);
                isPlantBomb = true;
            }

            if (animator.transform.position.x <= xpos && !isStartLeft)
            {
                animator.GetComponent<VL_P1_BatShot1>().SetBulletPostion(xpos, animator.transform.position.y);
                isPlantBomb = true;
            }
        }

        if (animator.GetInteger("PatternKey") == (int)BossStatesPhase1.VL_P1_BatShot2 && isPlantBomb == false)
        {
            if (animator.transform.position.x >= xpos && isStartLeft)
            {
                animator.GetComponent<VL_P1_BatShot2>().SetBulletPostion(xpos, animator.transform.position.y);
                isPlantBomb = true;
            }

            if (animator.transform.position.x <= xpos && !isStartLeft)
            {
                animator.GetComponent<VL_P1_BatShot2>().SetBulletPostion(xpos, animator.transform.position.y);
                isPlantBomb = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isPlantBomb = false;
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
