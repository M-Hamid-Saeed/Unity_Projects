using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
    public float speed;
    private Animator characterAnim;
    [SerializeField] private bool isGrounded = true;
    [SerializeField]private bool isJumping;
    [SerializeField] private bool isSliding;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private bool hadJumped = false;
    private Vector2 slideStartPostion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        characterAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);

        // Move the player horizontally
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        characterAnim.SetBool("IsRunning", Mathf.Abs(moveInput) > 0);
        Vector2 Xvalue = transform.localScale;
        if (moveInput > 0) {

            Xvalue.x *= 1;
        }
        if(moveInput < -0.006)
            Xvalue.x *= -1;

        if (isGrounded && Input.GetKey(KeyCode.Space)) {
            // Apply vertical force to make the player jump
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            characterAnim.SetBool("IsJump", true);
        }
      
    }

   
   
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("TileMap")) {
           
            isGrounded = true;
            characterAnim.SetBool("IsJump", false);
        }
        Debug.Log(isGrounded);
    }
}
