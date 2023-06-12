using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    public int pointValue;
   
    private GameManager gameManager;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void OnMouseDown() {
        if (!gameManager.isGameOver) {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();         
        }
        Destroy(gameObject);
    }
    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);

    }
    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
