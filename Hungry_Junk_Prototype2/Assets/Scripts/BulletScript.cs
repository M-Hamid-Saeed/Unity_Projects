using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager score;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animals"))
        {
            score.increaseScore();         
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        
        
    }

}
