using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : StateMachineBehaviour
{
    [SerializeField] private int speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 velocity = Vector3.zero;
        GameObject currentPlayerEmplacementAtk = FindObjectOfType<ChosePlayer>().currentPlayerEmplacementAtk;
        EnemyAction enemyAction = FindObjectOfType<EnemyAction>();
        enemyAction.currentEnemy.gameObject.transform.position = Vector3.SmoothDamp(enemyAction.currentEnemy.gameObject.transform.position, currentPlayerEmplacementAtk.transform.position, ref velocity, speed * Time.deltaTime); 
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
