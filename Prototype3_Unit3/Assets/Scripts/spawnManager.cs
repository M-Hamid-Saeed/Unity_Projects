using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnpos1 = new Vector3(40, 0, 0);
    private Vector3 spawnpos2 = new Vector3(40, 1.5f, 0);
    private float startDelay = 2;
    private float spawnDelay = 2;
    private PlayerCOntroller playerScript;
    // Start is called before the first frame update
    void Start()
    {
  

        InvokeRepeating("spawningObstacles", startDelay, spawnDelay);
        playerScript = GameObject.Find("Player").GetComponent<PlayerCOntroller>();
     

      
    }
    private void Update()
    {
        
    }
    public void spawningObstacles()
    {

        if (!playerScript.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnpos1, obstaclePrefab.transform.rotation);
            Instantiate(obstaclePrefab, spawnpos2, obstaclePrefab.transform.rotation);

        }
        

    }
}
