using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIncrease : MonoBehaviour
{
    public Player player;

    [SerializeField]
    private Text pickupText;
    private bool pickUpAllowed;
    // Start is called before the first frame update
    void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))		
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickupText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickupText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
		
		if (AudioManager.instance != null) { // Let the script continue working
			AudioManager.instance.Play("Upgrade_Pickup");
		}
		
        Debug.Log("Picked up Health");
        if (player.playerStats.currentHealth < player.playerStats.maxHealth - 20)
        {
            player.playerStats.currentHealth += 20;
        }
        else if(player.playerStats.currentHealth > player.playerStats.maxHealth - 20)
        {
            player.playerStats.currentHealth = player.playerStats.maxHealth;
        }
        else
        {
            player.playerStats.maxHealth += 10;
        }
        
        Destroy(gameObject);
    }
}
