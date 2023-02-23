using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = System.Random;

public class SpiderSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject spiderPrefab;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private List<GameObject> windows;
    private static Random random = new Random();

    private float timeSinceLastSpawn;

    // Update is called once per frame
    void Update()
    {
        if (!IsServer)
            return;

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnRate)
        {
            timeSinceLastSpawn = 0;
            SpawnSpider();
        }
    }

    private void SpawnSpider()
    {
        var randomWindowIndex = random.Next(0, windows.Count);
        var randomWindowX = windows[randomWindowIndex].transform.position.x;
        var spawnPosition = new Vector3(randomWindowX, 1.4f, 0.04f);
        var spider = NetworkObjectPool.Singleton.GetNetworkObject(spiderPrefab, spawnPosition, spiderPrefab.transform.rotation);
        spider.Spawn();
    }
}
