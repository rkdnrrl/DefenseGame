using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnManager : NetworkBehaviour
{
    public Transform[] spawnPosition;
    public GameObject enemyPrefab;

    private void Start()
    {
        if(isServer)
        StartCoroutine(SpawnTime());
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnEnemy();
        }
    }

    [Server]
    void SpawnEnemy()
    {
        int randomPos = Random.Range(0, spawnPosition.Length);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition[randomPos].position, Quaternion.identity);
        NetworkServer.Spawn(enemy);
    }
}
