using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float movingSpeed = 10f;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        walk();
    }
    private void walk()
    {
        if (horizontalInput < 0)
        {
            Vector2 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            playerAnim.SetBool("isRun", true);
            Debug.Log("Horizontal less 0");
        }
        else if (horizontalInput > 0)
        {
            Vector2 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            playerAnim.SetBool("isRun", true);
            Debug.Log("Horizontal greater 0");
        }
        else if (horizontalInput == 0)
        {
            playerAnim.SetBool("isRun", false);
        }

        transform.Translate(Vector2.right * horizontalInput * movingSpeed * Time.deltaTime, Space.Self);
    }
    
}
