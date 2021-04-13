using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour
{
	public float speed;
	private bool movingRight = true;
	public Transform groudDetection;
	
	private Transform player;
	public float how_close; // Detection radius
	private float dist;
	
	public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		//Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
		dist = Vector2.Distance(player.position, transform.position);
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		
		RaycastHit2D groundInfo = Physics2D.Raycast(groudDetection.position, Vector2.down, 2f);
		
		if (dist <= how_close) {
			animator.SetBool("is_chasing", true);
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
		else {
			animator.SetBool("is_chasing", false);
			if (groundInfo.collider == false) {
				if (movingRight == true) {
					transform.eulerAngles = new Vector3(0, -180, 0);
					movingRight = false;
				}
				else {
					transform.eulerAngles = new Vector3(0, 0, 0);
					movingRight = true;
				}
			}
		}		
	
		
    }
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}
}
