using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingDamage : MonoBehaviour
{

    public int damage = 100;
	private float delayDamage;
	public float startDamage;
	
    void Start()
    {
        delayDamage = startDamage;
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
			player.DamagePlayer(damage);
        }		
    }

    //Damage Player Function
    void OnTriggerStay2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
			if (delayDamage <= 0) {
				player.DamagePlayer(damage);
				delayDamage = startDamage;
			}
			else {
				delayDamage -= Time.deltaTime;
			}			
        }		
    }
}
