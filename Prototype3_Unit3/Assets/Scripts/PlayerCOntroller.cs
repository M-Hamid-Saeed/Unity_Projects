using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCOntroller : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float jumpForce;
    private bool isonGround = true;
    [SerializeField] private float gravityModifier;
    public bool isgameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionPart;
    public ParticleSystem dirtPart;
    public AudioClip crashSound;
    public AudioClip jumpsSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonGround && !isgameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce);
            isonGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtPart.Stop();
            playerAudio.PlayOneShot(jumpsSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("ground"))
        {
            isonGround = true;
            dirtPart.Play();

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("In Obstacle Collision");

            isgameOver = true;
            dirtPart.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionPart.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);


        }

    }
}
