using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    
	public Animator animator ;

	public Transform attackPoint;
	public float attackRange = 0.5f ;
	public LayerMask enemyLayers;


	public int attackDamage = 40 ;

	public float attackRate = 2f ;
	float nextAttackTime = 0f ;

    // Update is called once per frame
    void Update()
    {
		
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Attack();
				nextAttackTime = Time.time + 1f /attackRate ;
			}
		
		
    }

	void Attack()
	{
		animator.SetTrigger("Attack") ;

		
	}

	void OnDrawGizmosSelected()
	{

		if(attackPoint == null)
			return;
		
		Gizmos.DrawWireSphere(attackPoint.position, attackRange) ;
	}

	void AttackDamage()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Enemy>().TakeDamage(20) ;
		}
	}
}


