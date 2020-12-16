using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSmashBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttacks PA = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
        PlayerSFX PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSFX>();
        animator.SetBool("Smash1", false);
        animator.SetBool("Smash2", false);
        PA.Damage(PA.hulkDamage);
        PS.PlayAttack();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttacks PA = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
        PA.isAttacking = false;
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
