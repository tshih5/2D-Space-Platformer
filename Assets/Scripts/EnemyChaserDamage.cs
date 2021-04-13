using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserDamage : MonoBehaviour
{
    public int damage = 0;

    //Damage Player Function
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.DamagePlayer(damage);
        }
    }
}
