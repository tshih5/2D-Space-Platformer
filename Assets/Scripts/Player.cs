using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;
        public int currentHealth;
        public int deathCount = 0;
    }
    
    public PlayerStats playerStats = new PlayerStats();

    public Text healthText;
    public HealthBar healthBar;

    public Text deathCountText;

    public int fallBoundary;

    public Transform spawnPoint;

    private void Start()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        healthBar.SetMaxHealth(playerStats.maxHealth);
    }

    private void Update()
    {
       if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(100);
        }
        healthText.text = playerStats.currentHealth + " HP";
        healthBar.SetHealth(playerStats.currentHealth);

        deathCountText.text = "Deaths: " + playerStats.deathCount;
    }

    public void DamagePlayer (int damage)
    {
        playerStats.currentHealth -= damage;

        healthText.text = playerStats.currentHealth + " HP";
        healthBar.SetHealth(playerStats.currentHealth);
		
		if (AudioManager.instance != null) { // This if-check justs lets you still shoot if you don't load scene from Menu :p
			AudioManager.instance.Play("Player_Hurt");
		}

        if (playerStats.currentHealth <= 0)
        {
            //Debug.Log("KILL PLAYER");
            //GameMaster.KillPlayer(this);
			
			if (AudioManager.instance != null) { // This if-check justs lets you still shoot if you don't load scene from Menu :p
			AudioManager.instance.Play("Player_Death");
			}
			
            playerStats.deathCount += 1;
            Score s = GameObject.Find("Score").GetComponent<Score>();
            if (s.score >= 50)
            {
                s.score -= 50;
            }
            else
            {
                s.score = 0;
            }
            RespawnPlayer();
        }
    }
    
    public void RespawnPlayer()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        gameObject.SetActive(false);
        /*if (Input.GetKeyDown("x")) //moved to RespawnSetActive script in _GM
        {
            gameObject.SetActive(true);
            playerStats.currentHealth = playerStats.maxHealth;
            transform.position = spawnPoint.position;
        }*/
    }

}
