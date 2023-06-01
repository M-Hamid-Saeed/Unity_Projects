using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCOntroller : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    private bool isOnGround = true;
    public float gravityModifier;
    public bool isGameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionPart;
    public ParticleSystem dirtPart;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    private int jumpCount = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver && jumpCount < 2)
        {
            Jump();
        }
    }

    private void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
        dirtPart.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        jumpCount++;
        if (jumpCount >= 2)
        {
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtPart.Play();
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            dirtPart.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionPart.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
