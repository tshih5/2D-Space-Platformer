using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSetActive : MonoBehaviour
{
    
    public GameObject player;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown("x") && (player.active == false))
        {
            player.SetActive(true);
            player.transform.position = spawnPoint.position;
        }
    }
}
