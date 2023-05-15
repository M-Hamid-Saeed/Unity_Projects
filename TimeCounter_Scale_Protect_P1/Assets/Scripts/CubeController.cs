using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float space;
    public float rotationSpeed;
    public float scalespeed;
    private bool isScaling;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 20;
        scalespeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CubeController");
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Debug.Log("CubeController 2 2222");

        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);
        transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed * verticalInput);
        if (Input.GetKeyDown(KeyCode.Space))
            isScaling = true;           
        if (Input.GetKeyUp(KeyCode.Space))
            isScaling = false;

        if (isScaling)
            transform.localScale += Vector3.one * Time.deltaTime * scalespeed;
        else
        {
            if (Vector3.Max(transform.localScale, Vector3.one) == transform.localScale) //vector3.max returns the maximum vector from each
                transform.localScale -= Vector3.one * Time.deltaTime * scalespeed;
            //if (transform.localScale.magnitude <= 1)
            //    transform.localScale = Vector3.one;
        }
        Debug.Log("33333");
    }
}
