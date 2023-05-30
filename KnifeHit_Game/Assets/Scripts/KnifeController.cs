using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private knifeSpawn knifespawn;
    public float throw_speed = 100;
    public UITextScore ui;
    private static int knivescount = 10;
    private static int score;
    public gameOverManager gameOver;
    public GameObject NewgameObject;
    private bool isGameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifespawn = FindObjectOfType<knifeSpawn>();
        ui = FindObjectOfType<UITextScore>();
        score = knifespawn.totalKnives;
    }

    private void Start()
    {
        gameOver = GameObject.Find("GameOverMan").GetComponent<gameOverManager>();
        Debug.Log(gameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (knivescount == 0)
                ui.winnerUI();
            if (Input.GetMouseButtonDown(0))
            {
                throwKnife();
                StartCoroutine(spawnWait());
            }
        }
        else
            resetScore();

    }

    IEnumerator spawnWait()
    {
        yield return new WaitForSeconds(0.5f);
        knifespawn.knifesetActive(); // set the next knife true         
    }

    private void throwKnife()
    {
        rb.AddForce(Vector2.up * throw_speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            rb.velocity = new Vector2(0, 0);
            this.transform.SetParent(collision.transform);
            gameObject.tag = "stuckedKnife";
            knivescount--;
            score++;
        }
        else if (collision.gameObject.CompareTag("stuckedKnife"))
        {
            isGameOver = true;
            Debug.Log("IN Collision with Stuck Knife");
            Debug.Log(gameOver.gameObject);
            gameOver.setactive();
            Time.timeScale = 0f;
        }

        callUI();
        StartCoroutine(deactivateScript());
    }

    IEnumerator deactivateScript()
    {
        yield return new WaitForSeconds(0.2f);
        this.enabled = false;
    }

    void callUI()
    {
        ui.setUI(score, knivescount);
    }
    
    void resetScore()
    {
        knivescount = 10;
        score = 0;
    }
}
