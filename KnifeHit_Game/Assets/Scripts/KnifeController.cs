using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private knifeSpawn knifespawn;
    public float throw_speed = 1200;
    private bool isthrowing = false;
    public UITextScore ui;
    private static int knivescount = 0;
    private static int score;
    private GameObject gameOver;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifespawn = FindObjectOfType<knifeSpawn>();
        ui = FindObjectOfType<UITextScore>();
        score = knifespawn.totalKnives;
        gameOver = GameObject.FindGameObjectWithTag("gameOver");
    }

    void Start()
    {
       

        // knifeIndex = knifespawn.totalKnives - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
                throwKnife();            
                StartCoroutine(spawnWait());
       
            
        }
        if (score == 0)
            ui.winnerUI();
    }
    IEnumerator spawnWait()
    {
        while (rb.velocity.magnitude > 0.3f)
            yield return null;// Wait until the current knife has stopped moving
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
            GetComponent<ParticleSystem>().Play();
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.gameObject.transform);
            knivescount++;
            score--;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver.SetActive(true);

        }
        
        callui();
        StartCoroutine(deactivate__Script());
        
        
    }

    IEnumerator deactivate__Script()
    {
        yield return new WaitForSeconds(1f);
        this.enabled = false;
    }

    void callui()
    {
        ui.setUI(knivescount, score);
    }
}

    
