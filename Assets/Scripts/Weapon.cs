using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum FireMode
    {
        SINGLE,
        THREEBURST,
        RAPID
    }
    //public AudioClip shotSound;
    //AudioSource audioSource;
    public float fireRate = 0;
    public int Damage = 10;
    public float effectSpawnRate = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
    public Transform impact;
    float timeToSpawnEffect = 0;
    float timeToFire = 0;
    Transform FirePoint;

    public FireMode fMode = FireMode.SINGLE;

    [System.Obsolete]
    void Awake()
    {
        FirePoint = transform.FindChild("FirePoint");
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && gameObject.transform.root != gameObject.transform)
        {
            switch (fMode)
            {
                case FireMode.SINGLE:
                    if (fireRate == 0)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            Shoot();
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
                        {
                            timeToFire = Time.time + 1 / fireRate;
                            Shoot();
                        }
                    }
                    break;

                case FireMode.THREEBURST:

                    if (Input.GetButton("Fire1") && Time.time > timeToFire)
                    {
                        Debug.Log("Bursting");
                        timeToFire = Time.time + 1 / fireRate;
                        StartCoroutine(BurstShoot());
                    }
                    break;

                case FireMode.RAPID:
                    if (fireRate == 0)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            Shoot();
                        }
                    }
                    else
                    {
                        if (Input.GetButton("Fire1") && Time.time > timeToFire)
                        {
                            timeToFire = Time.time + 1 / fireRate;
                            Shoot();
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }
    }

    public IEnumerator BurstShoot()
    {
        float fireDelay = 60f / 400;
        for(int i = 0; i < 3; ++i)
        {
            Shoot();
            yield return new WaitForSeconds(fireDelay);
        }
    }

    void Shoot()
    {
        UnityEngine.Vector2 mousePosition = new UnityEngine.Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        UnityEngine.Vector2 firePointPosition = new UnityEngine.Vector2(FirePoint.position.x, FirePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        
        if(hit.collider != null)
        {
            //Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("Hit Object: " + hit.collider.name);
            Debug.Log("Damage Dealt: " + Damage);

            //added this back
            if (hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.DamageEnemy(Damage);
                }
            }
        }
        if(Time.time >= timeToSpawnEffect)
        {
            UnityEngine.Vector3 hitPosition;
            UnityEngine.Vector3 hitNormal;
            if(hit.collider == null)
            {
                hitPosition = (mousePosition - firePointPosition) * 26;
                hitNormal = new UnityEngine.Vector3(9999, 9999, 9999);
            } else
            {
                hitPosition = hit.point;
                hitNormal = hit.normal;
            }
            Effect(hitPosition, hitNormal);
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void Effect(UnityEngine.Vector3 hitPosition, UnityEngine.Vector3 hitNormal)
    {
        //audioSource.PlayOneShot(shotSound);
		if (AudioManager.instance != null) { // This if-check justs lets you still shoot if you don't load scene from Menu :p
			AudioManager.instance.Play("Bullet_Shot");
		}
        Transform bulletTrail = Instantiate(BulletTrailPrefab, FirePoint.position, FirePoint.rotation) as Transform;
        LineRenderer line = bulletTrail.GetComponent<LineRenderer>();
        if(line != null)
        {
            line.SetPosition(0, FirePoint.position);
            line.SetPosition(1, hitPosition);
        }

        if (hitNormal != new UnityEngine.Vector3(9999, 9999, 9999))
        {
                Transform impact_trail = Instantiate(impact, hitPosition, UnityEngine.Quaternion.FromToRotation(UnityEngine.Vector3.right, hitNormal)) as Transform;
				Destroy(impact_trail.gameObject, 0.5f);
        }
        Destroy(bulletTrail.gameObject, 0.02f);
        Transform clone = Instantiate(MuzzleFlashPrefab, FirePoint.position, FirePoint.rotation) as Transform;
        clone.parent = FirePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new UnityEngine.Vector3(size, size, 0);
        Destroy(clone.gameObject, 0.01f);
    }
}
