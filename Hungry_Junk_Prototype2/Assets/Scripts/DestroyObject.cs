using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float upperBounds = 30;
    private float lowerBounds = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > upperBounds)
            Destroy(gameObject);
        else if (transform.position.z < lowerBounds)
            Destroy(gameObject);
    }
}
