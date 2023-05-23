using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject slabPrefab;
    public GameObject coinPrefab;
    private float lastSpawnX = -6.5f;
    private float slabSpawnDistance = 2.5f;
    private float spawnYpos = 7f;
    private float lastSpawnedTime;
    private float spawnInterval = 2f;
    public PlayerMovement health;
    // Start is called before the first frame update
    void Start()
    {
        spawnSlabs();
    }

    // Update is called once per frame
    void Update()
    {
      if(Time.time-lastSpawnedTime > spawnInterval && health.currentHealth!=0)
        {
            spawnSlabs();
        }  
    }
    void spawnSlabs()
    {
        bool spawnCoin = Random.value < 0.3;
        int index = Random.Range(0, 5);
        for (int i = 0; i < 5; i++)
        {
            if (i == index)
            {
                lastSpawnX += slabSpawnDistance;
                if(spawnCoin)
                    Instantiate(coinPrefab, new Vector2(lastSpawnX,spawnYpos), Quaternion.identity);
                continue;
            } 
            
                Instantiate(slabPrefab, spawnPositionReturn(), Quaternion.identity);
        }
        lastSpawnX = -spawnYpos;
        lastSpawnedTime = Time.time;

    }
    Vector2 spawnPositionReturn()
    {
        lastSpawnX += slabSpawnDistance;
        return new Vector2(lastSpawnX, spawnYpos);

    }
}
