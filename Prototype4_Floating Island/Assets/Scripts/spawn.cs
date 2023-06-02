using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float spawnRange = 9;
    public GameObject enemyPrefab;
    public int enemyCount;
    private int wavecount = 1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnRandom(wavecount);
        Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {

            Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
            spawnRandom(1);
            wavecount++;
        }
            
    }

    private void spawnRandom(int enemiestoSpawn)
    {
        for (int i = 0; i < enemiestoSpawn; i++)
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
    }
    private Vector3 GenerateRandomPos()
    {
        float RandomX = Random.Range(-spawnRange, spawnRange);
        float RandomZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(RandomX, 0, RandomZ);
    }
}
