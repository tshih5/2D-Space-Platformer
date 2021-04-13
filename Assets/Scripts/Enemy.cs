using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;
        public int currentHealth;
    }

    public EnemyStats enemyStats = new EnemyStats();

    public Text healthText;
    public HealthBar healthBar;

    private void Start()
    {
        enemyStats.currentHealth = enemyStats.maxHealth;
        healthBar.SetMaxHealth(enemyStats.maxHealth);
    }

    private void Update()
    {
        healthText.text = enemyStats.currentHealth + " HP";
    }

    public void DamageEnemy (int damage)
    {
        enemyStats.currentHealth -= damage;
        healthText.text = enemyStats.currentHealth + " HP";
        healthBar.SetHealth(enemyStats.currentHealth);
		
		if (AudioManager.instance != null) { // Let the script continue working
			AudioManager.instance.Play("Enemy_Hurt");
		}

        if (enemyStats.currentHealth <= 0)
        {
            //Debug.Log("KILL ENEMY");
            Score s = GameObject.Find("Score").GetComponent<Score>();
            s.score += 100;
            GameMaster.KillEnemy(this);
        }
    }

    /*    public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                DamagePlayer(5);
            }
        }
     */
}
