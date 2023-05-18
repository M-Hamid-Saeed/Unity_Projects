using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] animals;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startInterval = 2f;
    private float spawnInterval = 1.5f;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomAnimals", startInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
    void spawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, animals.Length);
        spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); 
        Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation);


    }
}
