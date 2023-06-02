using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float spawnRange = 9;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnRandom();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnRandom()
    {
        Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
    }
    private Vector3 GenerateRandomPos()
    {
        float RandomX = Random.Range(-spawnRange, spawnRange);
        float RandomZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(RandomX, 0, RandomZ);
    }
}
