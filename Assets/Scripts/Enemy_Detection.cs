using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Detection : MonoBehaviour
{
	public AIPath aiPath;
	private Transform player;
	public float how_close; // Detection radius
	private float dist;
	
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.enabled = false; // Disable AIPath script at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
        }		
        dist = Vector2.Distance(player.position, transform.position); // Distance between player and enemy
		
		if (dist <= how_close) { // If player is within detection radius, enable pathfinding script
			aiPath.enabled = true;
		}
    }
}
