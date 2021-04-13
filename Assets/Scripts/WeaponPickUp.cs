using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WeaponPickUp : MonoBehaviour
{
    public Transform weaponHolder;
    public Transform aim;
    public float angle;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            AddToParent(weaponHolder, aim);
            //Destroy(gameObject);
        }
    }

    public void AddToParent(Transform newParent, Transform aim)
    {
        Vector3 temp = aim.eulerAngles;
        aim.eulerAngles = new Vector3(0, 0, 0);
        aim.localScale = Vector3.one;
        //offset to player when adding weapon to WeaponHolder
        Vector3 offset = new Vector3(.5f, 0f, 0f);
        gameObject.transform.position = newParent.transform.position + offset;
        gameObject.SetActive(false);
        gameObject.transform.SetParent(newParent);
    }
}
