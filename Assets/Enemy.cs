using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
	public int maxHealth = 100;
	int currentHealth ;


	Countdown c ;

    void Start()
    {
        currentHealth = maxHealth ;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage ;

		if(currentHealth <= 0)
		{
			Die() ;
		}
    }

	
	void Die()
	{
		Debug.Log("Enemy died!") ;
		c = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Countdown>() ;
		c.HitTheBall(1);
		Destroy(gameObject) ;
	}

}
