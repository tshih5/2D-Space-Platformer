using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;

    public void RespawnPlayer()
    {
        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    public void Update()
    {
        DeletePlayerPrefs();
    }

    public void DeletePlayerPrefs()
    {
        //if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R)) //idk why taking multiple getkeydowns at the same time doesn't work most of the time?
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Debug.Log("delete all scores");
            PlayerPrefs.DeleteAll();
        }
        
        //PlayerPrefs.SetInt()
    }
}
