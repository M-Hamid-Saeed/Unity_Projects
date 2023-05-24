using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private knifeSpawn knifespawn;
    public float throw_speed = 100;
    private bool isthrowing = false;
    public UITextScore ui;
    private static int knivescount = 0;
    private static int score;
    public gameOverManager gameOver;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifespawn = FindObjectOfType<knifeSpawn>();
        ui = FindObjectOfType<UITextScore>();
        score = knifespawn.totalKnives;
        

        
    }
    private void Start()
    {
        // gameOver = GameObject.Find("EndGameCanvas");

        gameOver = GameObject.Find("GameOverMan").GetComponent<gameOverManager>();
        Debug.Log(gameOver);




    }

    // Update is called once per frame
    void Update()
    {
        if (score == 0)
            ui.winnerUI();

        if (Input.GetMouseButtonDown(0))
        {
                throwKnife();            
                StartCoroutine(spawnWait());          
        }
    }
    IEnumerator spawnWait()
    {
        while (rb.velocity.magnitude > 0f)
            yield return null;// Wait until the current knife has stopped moving
        yield return new WaitForSeconds(0.4f);
        knifespawn.knifesetActive(); // set the next knife true         

    }
    private void throwKnife()
    {
        rb.AddForce(Vector2.up * throw_speed*Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            
            rb.velocity = new Vector2(0, 0);
           
            this.transform.SetParent(collision.transform);
            gameObject.tag = "stuckedKnife";
            knivescount++;
            score--;

        }

        else if (collision.gameObject.CompareTag("stuckedKnife"))
        {
            Debug.Log("IN COllision with Stucked Knife");
            Debug.Log(gameOver.gameObject);
            gameOver.setactive();



        }

        callui();
        StartCoroutine(deactivate__Script());
        
        
    }

    IEnumerator deactivate__Script()
    {
        yield return new WaitForSeconds(0.2f);
        this.enabled = false;
    }

    void callui()
    {
        ui.setUI(knivescount, score);
    }
}

    
