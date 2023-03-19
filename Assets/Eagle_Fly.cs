using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Fly : StateMachineBehaviour
{
	Transform player;
	Rigidbody2D rb;
	Eagle_Flip eagle_Flip ;
	public float attackRange = 1f ;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
	   rb = animator.GetComponentInParent<Rigidbody2D>();
	   eagle_Flip = animator.GetComponent<Eagle_Flip>() ;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		eagle_Flip.LookAtPlayer();

       if(Vector2.Distance(player.position, rb.position) <= attackRange )
	   {
		animator.SetTrigger("Attack") ;
	   }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack") ;
    }

 
}
