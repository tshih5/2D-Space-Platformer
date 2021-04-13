using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
	public Transform player;
	public float how_close;
	private float dist;
	
	private float delayShots;
	public float startShots;
	public GameObject projectile;
	
	public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        delayShots = startShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
        }		
        dist = Vector2.Distance(player.position, transform.position);
		if (dist <= how_close) {
			animator.SetBool("is_shooting", true);
			if (delayShots <= 0) {
				var test = Instantiate(projectile, transform.position, Quaternion.identity);
                test.gameObject.tag = "Enemy"; //added "var test = " above and added this line here -Daniel
                //test.gameObject.isTrigger = true;
                delayShots = startShots;
			}
			else {
				delayShots -= Time.deltaTime;
			}			
		}
		else {
			animator.SetBool("is_shooting", false);
		}
    }
}
