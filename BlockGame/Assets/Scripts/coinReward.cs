using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinReward : MonoBehaviour
{
    public PlayerMovement health;
    // Start is called before the first frame update
    void Start()
    {
       health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { if (health.currentHealth < 100)
        {
            health.currentHealth += 25;
            health.healthset();
        }
        Destroy(gameObject);

    }
}
