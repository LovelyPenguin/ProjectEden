using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBulletPosition : StateMachineBehaviour
{
    public GameObject bullet;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //GameObject bullet = Instantiate(this.bullet, animator.transform.position, Quaternion.identity);
        //Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        //bulletRigidBody.AddForce(new Vector2(0, animator.GetFloat("Phase1_Bullet_Speed") * -1), ForceMode2D.Impulse);
        animator.GetComponent<VL_P1_BatShot1>().SetBulletPostion();
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
