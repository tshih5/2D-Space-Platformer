using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class PlayerAimWeapon : MonoBehaviour
{
    public Vector3 mousePosition;
    public float angle;
    private Transform aimTransform;
    public SpriteRenderer muzzleFlashRend;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        muzzleFlashRend.color = new Color(0,0,0,0);
    }
    private void Update()
    {
        HandleAim();
        HandleShooting();
    }
    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
			FindObjectOfType<AudioManager>().Play("Bullet_Shot");
            StartCoroutine(MuzzleFlash(0.02f));
        }
    }
    private void HandleAim()
    {
        mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 offsetPosition = new Vector3(0.0f, 0.6f, 0.0f);
        Vector3 aimDirection = (mousePosition - transform.position - offsetPosition).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(aimDirection);
        Vector3 localScale = Vector3.one;
        if(angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }
        aimTransform.localScale = localScale;
       // Debug.Log(angle);
    }
    IEnumerator MuzzleFlash(float duration)
    {
        muzzleFlashRend.color = new Color(1, 1, 1, 1);
        muzzleFlashRend.gameObject.transform.Rotate(Random.Range(0, 2) * 180, 0, 0);
        yield return new WaitForSeconds(duration);
        muzzleFlashRend.color = new Color(0, 0, 0, 0);
    }
}
