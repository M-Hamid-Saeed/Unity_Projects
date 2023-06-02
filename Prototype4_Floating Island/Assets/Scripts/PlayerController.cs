using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;
    private GameObject focalpoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal Point");


    }

    // Update is called once per frame
    void Update()
    {
        playerRB.AddForce(focalpoint.transform.forward * Input.GetAxis("Vertical") * speed);
        
    }
}
