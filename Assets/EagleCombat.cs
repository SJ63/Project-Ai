using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCombat : MonoBehaviour
{
    public float attackTime = 1 ;
	public Vector3 attackOffset;
	public float attackRange = 1f ;
	public LayerMask attackMask ;

	Countdown c ;

	public void EagleAttack()
	{
		Vector3 pos = transform.position ;
		pos += transform.right * attackOffset.x ;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask) ;
		if(colInfo != null)
		{
			Debug.Log("Enemy is hitted") ;
			c = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Countdown>() ;
			c.refute(attackTime) ;
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
