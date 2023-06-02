using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalpoint;
    public GameObject powerupIndict;

    public bool haspower=false;
    public float powerStrength;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal Point");


    }

    // Update is called once per frame
    void Update()
    {
        powerupIndict.gameObject.transform.position = transform.position;
        playerRB.AddForce(focalpoint.transform.forward * Input.GetAxis("Vertical") * speed);
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && haspower)
        {
            Rigidbody enemyrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forcedirection = collision.gameObject.transform.position - transform.position;

            enemyrb.AddForce(forcedirection * powerStrength, ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUP"))
        {
            powerupIndict.SetActive(true);
            haspower = true;
            Destroy(other.gameObject);
            StartCoroutine(powerupCountdown());
        }
    }
    IEnumerator powerupCountdown()
    {
        yield return new WaitForSeconds(7);
        powerupIndict.SetActive(false);
        haspower = false;
    }

}
