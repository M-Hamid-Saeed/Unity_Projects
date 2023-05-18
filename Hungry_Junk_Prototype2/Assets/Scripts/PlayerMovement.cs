using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float speed;
    private float xRange = 10;
    public GameObject projectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalInput * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), transform.rotation);
        }
    }
}
