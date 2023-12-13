using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject mini;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnMini", 1, 1);
    }

    private void SpawnMini()
    {
        GameObject newMini = Instantiate(mini);
        Vector3 playerDirection = (player.transform.position - transform.position).normalized * 3f;
        Vector3 spawnOffset = new Vector3(playerDirection.x, 0, playerDirection.z);
        newMini.transform.position = transform.position + spawnOffset;
        newMini.GetComponent<Enemy2>().SetDirection(player.transform.position - transform.position);
    }
}
