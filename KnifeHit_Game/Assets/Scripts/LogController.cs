using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float reverseDuration = 0.5f; // Minimum duration for reverse rotation
    private float reverseTimer = 0f; // Timer for reverse rotation

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if reverse rotation is active
        if (reverseTimer > 0f)
        {
            reverseTimer -= Time.deltaTime;
        }
        else
        {
            if (Random.value < 0.005f)
            {
                rotationSpeed -= 20;
                rotationSpeed *= -1;

                // Set the reverse timer to the reverse duration
                reverseTimer = reverseDuration;
            }
        }

        rotate();
    }

    void rotate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
