using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnpos = new Vector3(40, 0, 0);
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

        if (!playerScript.isgameOver)
        {
            Instantiate(obstaclePrefab, spawnpos, obstaclePrefab.transform.rotation);

        }
        

    }
}
