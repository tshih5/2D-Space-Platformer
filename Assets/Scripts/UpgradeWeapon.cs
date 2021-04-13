using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeapon : MonoBehaviour
{
    //public Weapon pistol;
    public Transform weaponHolder;

    // Start is called before the first frame update
    [SerializeField]
    private Text pickupText;
    private bool pickUpAllowed;
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
		
        Debug.Log("Picked up Upgrade");
        foreach (Transform weapon in weaponHolder)
        {
            weapon.gameObject.GetComponent<Weapon>().Damage += 5;
        }
        Destroy(gameObject);
    }
}
