using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
    public float speed;
    private Animator characterAnim;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isSliding;
    [SerializeField] private bool hadJumped = false;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float slideDistance;
    private Rigidbody2D rb;
    private float moveInput;

    // Start is called before the first frame update
    void Start() {
        characterAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        moveInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        characterAnim.SetBool("IsRunning", Mathf.Abs(moveInput) > 0.02 && isGrounded);

        if (moveInput > 0) {
            transform.localScale = new Vector3(0.33f, 0.33f, 1f);
        }
        else if (moveInput < 0) {
            transform.localScale = new Vector3(-0.33f, 0.33f, 1f);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            // Apply vertical force to make the player jump

            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            characterAnim.SetBool("IsJump", true);
            isGrounded = false;
            hadJumped = true;
        }
        if (hadJumped && isGrounded) {
            Debug.Log("Sliding");
            characterAnim.SetBool("IsSlide", true);
            for (int i = 0; i < 10; i++) {
                rb.velocity = new Vector2(transform.right.x * slideDistance, rb.velocity.y);
            }

            hadJumped = false;
        }
        else
            characterAnim.SetBool("IsSlide", false);
    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("TileMap")) {
            characterAnim.SetBool("IsJump", false);
            isGrounded = true;
           
        }
        Debug.Log(collision.gameObject.tag);
        Debug.Log(isGrounded);
    }
}
