using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject wavePrefab;
    public Transform playerTransform;
  
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            spawnWave();
        }
    }
    void spawnWave()
    {
      
        
           GameObject wave = Instantiate(wavePrefab, playerTransform.position, playerTransform.rotation);
           wave.transform.SetParent(playerTransform);
        
    }
   
}
