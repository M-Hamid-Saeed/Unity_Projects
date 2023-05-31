using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float scaleSpeed = 0.2f;
    public float ForwardSpeed;
   
    float minY = 0.4f;
    float maxY = 3f;
    float minX = 0.4f;
    float maxX = 3f;
    public float bounceBackForce = 100f;
    private Rigidbody cubeRB;
    public AudioClip blipSound;
    private AudioSource playerAudioSource;
    public ParticleSystem collisionParticle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        cubeRB = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {

        scaleCube();
        movingCube();

    }
   

    private void scaleCube() {
        
        float verticalInput = Input.GetAxis("Vertical");

       
        float newScaleX = transform.localScale.x - verticalInput * scaleSpeed * Time.deltaTime;
        float newScaleY = transform.localScale.y + verticalInput * scaleSpeed * Time.deltaTime;

        // Clamp the scale within the specified range
        newScaleX = Mathf.Clamp(newScaleX, minX, maxX);
        newScaleY = Mathf.Clamp(newScaleY, minY, maxY);
       

        transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);

        
    }
    private void movingCube()
    {
        //transform.Translate(Vector3.forward * ForwardSpeed* Time.deltaTime);
        cubeRB.velocity = transform.forward * ForwardSpeed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Hurdles"))
        {
            //cubeRB.AddForce(Vector3.back * bounceBackForce, ForceMode.Impulse);

            playerAudioSource.PlayOneShot(blipSound, 1.0f);
            collisionParticle.Play();
        }
       
        
    }
}
