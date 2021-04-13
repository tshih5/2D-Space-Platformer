using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
	public Transform target;
	private SpriteRenderer mySpriteRenderer;
	
    // Start is called before the first frame update
    void Start()
    {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x <= this.transform.position.x) {
			mySpriteRenderer.flipX = false;
		}
		else if (target.position.x >= this.transform.position.x) {
			mySpriteRenderer.flipX = true;
		}
    }
}
